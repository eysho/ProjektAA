using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Modules
{
    internal enum FarmState
    {
        Enabled = 0,
        AttackOnlyAgro = 1,
        Disabled = 2,
        Doodads = 3,
        DoodadsAndMobs = 4
    }

    internal class FarmModule : Module
    {
        private uint[] specialItems;
        private FarmState _farmState;
        internal FarmState farmState
        {
            get
            {
                return _farmState;
            }
            set
            {
                _farmState = value;
                host.mainForm.SetFarmModuleText(_farmState.ToString());
            }
        }
        private List<uint> farmMobsIds = new List<uint>();
        private List<uint> farmDoodadsIds = new List<uint>();
        private Zone farmZone = new RoundZone(0, 0, 0);
        private Creature bestMob = null;
        private double doodadCastDist = 1;
        public bool readyToActions = true;

        public override void Start(Host host)
        {
            base.Start(host);
            farmState = FarmState.Disabled;
        }

        public int aggroMobsCount()
        {
            int result = 0;

            var l1 = host.getAggroMobs();
            foreach (var m in l1)
            {
                if (host.me.Z - m.Z < 15)
                    result++;
            }
            l1 = host.getAggroMobs(host.getMount());
            foreach (var m in l1)
            {
                if (host.me.Z - m.Z < 15)
                    result++;
            }
            return result;
        }

        private void UseSkillAndWait(uint skillId, bool selfTarget = false, bool suspendMovements = false)
        {
            while (host.me.isCasting || host.me.isGlobalCooldown)
                Thread.Sleep(50);
            if (suspendMovements)
                host.SuspendMoveToBeforeUseSkill(true);
            if (!host.UseSkill(skillId, true, selfTarget))
            {
                if (host.me.target != null && host.GetLastError() == LastError.NoLineOfSight)
                {
                    Console.WriteLine("No line of sight, try come to target.");
                    if (host.dist(host.me.target) <= 5)
                        host.ComeTo(host.me.target, 2);
                    else if (host.dist(host.me.target) <= 10)
                        host.ComeTo(host.me.target, 3);
                    else if (host.dist(host.me.target) < 20)
                        host.ComeTo(host.me.target, 8);
                    else
                        host.ComeTo(host.me.target, 8);
                }
            }
            while (host.me.isCasting || host.me.isGlobalCooldown)
                Thread.Sleep(50);
            if (suspendMovements)
                host.SuspendMoveToBeforeUseSkill(false);
        }

        private void UseItemAndWait(uint itemId, bool suspendMovements = false)
        {
            while (host.me.isCasting || host.me.isGlobalCooldown)
                Thread.Sleep(50);
            if (suspendMovements)
                host.SuspendMoveToBeforeUseSkill(true);
            if (!host.UseItem(itemId, true))
            {
                if (host.me.target != null && host.GetLastError() == LastError.NoLineOfSight)
                {
                    Console.WriteLine("No line of sight, try come to target.");
                    if (host.dist(host.me.target) <= 5)
                        host.ComeTo(host.me.target, 2);
                    else if (host.dist(host.me.target) <= 10)
                        host.ComeTo(host.me.target, 3);
                    else if (host.dist(host.me.target) < 20)
                        host.ComeTo(host.me.target, 8);
                    else
                        host.ComeTo(host.me.target, 8);
                }
            }
            while (host.me.isCasting || host.me.isGlobalCooldown)
                Thread.Sleep(50);
            if (suspendMovements)
                host.SuspendMoveToBeforeUseSkill(false);
        }

        private void CheckUnderWaterBreath()
        {
            if (host.me.isUnderWaterBreath && host.me.underWaterBreathTime < 20000)
            {
                try
                {
                    host.SwimUp(true);
                    while (host.me.isAlive() && host.me.isUnderWaterBreath)
                        Thread.Sleep(10);
                }
                finally
                {
                    host.SwimUp(false);
                }
            }
        }

        private void UseRegenItems()
        {
            if (!host.me.isAlive())
                return;
            if (host.me.inFight)
            {
                //Банки, моментально юзаются
                if (host.me.hpp < 60)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 18791 || i.id == 34006 || i.id == 34007));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id);
                }
                if (host.me.mpp < 70)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 18792 || i.id == 34008 || i.id == 34009));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id);
                }
            }
            else
            {
                //Печенье и т.п., юзается за 1-2 сек
                if (host.me.hpp < 60)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 34003 || i.id == 34001 || i.id == 34000));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id, true);
                }
                if (host.me.mpp < 70)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 34002 || i.id == 34005 || i.id == 34004));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id, true);
                }
            }
        }

        private void ControlMount()
        {
            var mount = host.getMount();
            if (mount != null)
            {
                if (mount.hpp < 50 && aggroMobsCount() > 0)
                {
                    host.DespawnMount();
                    return;
                }
            }
            else
            {
                if (aggroMobsCount() == 0 && host.mobsInRange(25,false) == 0)
                {
                    host.UseItem(4941);
                    return;
                }
            }
        }

        private void FarmRoute()
        {
            CheckUnderWaterBreath();
            UseRegenItems();
            //ControlMount();
            if (bestMob == null)
                return;
            if (host.me.target != bestMob && host.isAlive(bestMob))
                host.SetTarget(bestMob);
            if (host.angle(bestMob, host.me) > 45 && host.angle(bestMob, host.me) < 315) //если нужно - поворачиваемся к нему лицом
                host.TurnDirectly(bestMob);
            if (host.me.target == bestMob && host.isAlive(bestMob))
            {
                if (specialItems != null)
                    for (int i = 0; i < specialItems.Length; i++)
                    {
                        UseItemAndWait(specialItems[i]);
                        Thread.Sleep(500);
                    }
                if (host.isExists(bestMob) && host.isAlive(bestMob)) //т.к. можем кастовать в никуда\на себя - лишние проверки
                    UseSkillAndWait(11379);
                UseSkillAndWait(10667);
                if (host.isExists(bestMob) && host.isAlive(bestMob) && host.me.dist(bestMob) < 4 && !host.isSpellImmune(bestMob) && (aggroMobsCount() == host.mobsInRange(7, false)))//т.к. можем кастовать в никуда\на себя - лишние проверки
                {
                    if (host.me.level < 30 && host.enemysInRange(15,false) == 0)
                        UseSkillAndWait(10135);
                    else if (host.me.level >= 30)
                        UseSkillAndWait(10135);
                }
                UseSkillAndWait(10752);
                UseSkillAndWait(10752);
                UseSkillAndWait(10752);
                
            }
            if (!host.isAlive(bestMob) && ((Npc)bestMob).dropAvailable && host.GetVar(bestMob, "pickFailed") == null)
            {
                Console.WriteLine("Come to pickup drop");
                host.ComeTo(bestMob);
                if (!host.PickupAllDrop(bestMob))
                    host.SetVar(bestMob, "pickFailed", true);
            }
        }

        public override void Run(CancellationToken ct)
        {
            while (true)
            {
                base.Run(ct);
                try
                {
                    if (!host.isAlive())
                    {
                        readyToActions = false;
                        while (host.me.resurrectionWaitingTime > 0)
                            Thread.Sleep(100);
                        Thread.Sleep(3000);
                        host.movementModule.ResumeGpsMove();
                        host.CancelMoveTo();
                        host.ResToRespoint();
                        Thread.Sleep(10000);
                        host.RestoreExp();
                        Thread.Sleep(2000);
                        farmState = FarmState.Disabled;
                        readyToActions = true;
                    }
                    if (host.isAlive())
                    {
                        if (host.buffTime(95) == 0 && host.buffTime(426) == 0 && host.buffTime(427) == 0 && host.buffTime(428) == 0 && host.buffTime(429) == 0 && host.skillCooldown(10153) == 0)
                            UseSkillAndWait(10153, false, true);

                        //Лут дропа рядом
                        host.farmModule.PickUpNearMe();
                    }

                    if (farmState == FarmState.Enabled)
                    {
                        if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !((Npc)bestMob).dropAvailable)) && ((host.mpp() > 40 && host.hpp() > 75) || aggroMobsCount() > 0))
                            bestMob = GetBestMob();
                        FarmRoute();
                    }
                    else if (farmState == FarmState.AttackOnlyAgro)
                    {
                        if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !((Npc)bestMob).dropAvailable)) && host.mpp() > 10)
                            bestMob = GetBestAgroMob();
                        if (bestMob != null && host.isExists(bestMob) && host.isAlive(bestMob) && host.movementModule.gpsMoveEnabled && !host.movementModule.gpsMoveSuspended)
                            host.movementModule.SuspendGpsMove();
                        if (aggroMobsCount() == 0 && host.movementModule.gpsMoveEnabled && host.movementModule.gpsMoveSuspended)
                            host.movementModule.ResumeGpsMove();
                        FarmRoute();
                    }
                    else if (farmState == FarmState.Doodads)
                    {
                        if (aggroMobsCount() == 0)
                        {
                            CheckUnderWaterBreath();
                            for (int i = 0; i < farmDoodadsIds.Count; i++)
                            {
                                var doodad = getNearestDoodadInZone(farmDoodadsIds[i]);
                                if (doodad != null)
                                {
                                    var skills = doodad.getUseSkills();
                                    if (skills.Count > 0)
                                    {
                                        if (doodadCastDist == 0)
                                            host.UseDoodadSkill(skills[0].id, doodad, true);
                                        else
                                        {
                                            host.ComeTo(doodad, doodadCastDist, doodadCastDist);
                                            if (host.me.dist(doodad) <= doodadCastDist)
                                                host.UseDoodadSkill(skills[0].id, doodad, true);
                                        }
                                        Thread.Sleep(1000);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !((Npc)bestMob).dropAvailable)) && host.mpp() > 10)
                                bestMob = GetBestAgroMob();
                            FarmRoute();
                        }
                    }
                    else if (farmState == FarmState.DoodadsAndMobs)
                    {
                        if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !((Npc)bestMob).dropAvailable)) && ((host.mpp() > 40 && host.hpp() > 75) || aggroMobsCount() > 0))
                            bestMob = GetBestMob();
                        if (bestMob == null)
                        {
                            CheckUnderWaterBreath();
                            for (int i = 0; i < farmDoodadsIds.Count; i++)
                            {
                                var doodad = getNearestDoodadInZone(farmDoodadsIds[i]);
                                if (doodad != null)
                                {
                                    var skills = doodad.getUseSkills();
                                    if (skills.Count > 0)
                                    {
                                        if (doodadCastDist == 0)
                                            host.UseDoodadSkill(skills[0].id, doodad, true);
                                        else
                                        {
                                            host.ComeTo(doodad, doodadCastDist, doodadCastDist);
                                            if (host.me.dist(doodad) <= doodadCastDist)
                                                host.UseDoodadSkill(skills[0].id, doodad, true);
                                        }
                                        Thread.Sleep(1000);
                                    }
                                }
                            }
                        }
                        else
                            FarmRoute();
                    }
                }
                catch (Exception error)
                {
                    //host.Log(error.ToString());
                }
                Thread.Sleep(10);
            }
        }

        public void SetFarmMobsFromDoodads(Zone zone, uint[] mobsIDs, uint[] doodadsIDs, double castDist = 0)
        {
            bestMob = null;
            lock (farmDoodadsIds)
                farmDoodadsIds = new List<uint>(doodadsIDs);
            lock (farmMobsIds)
                farmMobsIds = new List<uint>(mobsIDs);
            lock (farmZone)
                farmZone = zone;
            farmState = FarmState.DoodadsAndMobs;
            doodadCastDist = castDist;
        }

        public void SetFarmDoodads(Zone zone, uint[] ids, double castDist = 0)
        {
            bestMob = null;
            lock (farmDoodadsIds)
                farmDoodadsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            farmState = FarmState.Doodads;
            doodadCastDist = castDist;
        }

        public void SetFarmMobs(Zone zone, uint[] ids, uint[] UseSpecialItem)
        {
            bestMob = null;
            lock (farmMobsIds)
                farmMobsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            specialItems = UseSpecialItem;
            farmState = FarmState.Enabled;
        }

        public void SetFarmMobs(Zone zone, uint[] ids, uint UseSpecialItem = 0)
        {
            bestMob = null;
            lock(farmMobsIds)
                farmMobsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            if (UseSpecialItem > 0)
                specialItems = new uint[] { UseSpecialItem };
            else
                specialItems = null;
            farmState = FarmState.Enabled;
        }

        public void SetFarmAggros()
        {
            bestMob = null;
            farmState = FarmState.AttackOnlyAgro;
        }

        public void PickUpNearMe()
        {
            if (host.me.isAlive())
            {
                foreach (var m in host.getCreatures())
                {
                    if (m.dropAvailable && host.dist(m) < 5)
                    {
                        host.PickupAllDrop(m);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public void StopFarm()
        {
            bestMob = null;
            farmState = Modules.FarmState.Disabled;
        }

        public int getDoodadsCountInZone(Zone zone, uint phaseId)
        {
            int result = 0;
            foreach (var doodad in host.getDoodads())
            {
                if (doodad.phaseId == phaseId && zone.ObjInZone(doodad))
                    result++;
            }
            return result;
        }

        private DoodadObject getNearestDoodadInZone( uint phaseId)
        {
            double minDist = 999999;
            DoodadObject bestDoodad = null;
            foreach (var doodad in host.getDoodads())
            {
                if (doodad.phaseId == phaseId && farmZone.ObjInZone(doodad))
                {
                    if (minDist > host.me.dist(doodad))
                    {
                        minDist = host.me.dist(doodad);
                        bestDoodad = doodad;
                    }
                }

            }
            return bestDoodad;
        }

        internal Creature GetNearestCreaturesInZoneById(Zone zone, List<uint> creatureId)
        {
            try
            {
                Creature creature = null;
                var tempCreatures = host.getCreatures();
                double minDist = 999999;
                for (int i = 0; i < tempCreatures.Count; i++)
                {
                    if (creatureId.Exists(c => c == tempCreatures[i].creatureId) && host.dist(tempCreatures[i]) < minDist && zone.ObjInZone(tempCreatures[i]))
                    {
                        minDist = host.dist(tempCreatures[i]);
                        creature = tempCreatures[i];
                    }
                }
                return creature;
            }
            catch (Exception error)
            {

            }
            return null;
        }

        internal Creature GetNearestCreatureById(uint creatureId)
        {
            try
            {
                Creature creature = null;
                var tempCreatures = host.getCreatures();
                double minDist = 999999;
                for (int i = 0; i < tempCreatures.Count; i++)
                {
                    if (tempCreatures[i].creatureId == creatureId && host.dist(tempCreatures[i]) < minDist)
                    {
                        minDist = host.dist(tempCreatures[i]);
                        creature = tempCreatures[i];
                    }
                }
                return creature;
            }
            catch (Exception error)
            {
                
            }
            return null;
        }

        private Creature getNearestMobInZone(uint mobId)
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == mobId && host.isAlive(creature))
                {
                    if (minDist > host.me.dist(creature))
                    {
                        minDist = host.me.dist(creature);
                        bestCreature = creature;
                    }
                }

            }
            return bestCreature;
        }

        private Creature GetBestMob()
        {
            double bestDist = 999999;
            Creature bestMob = null;
            foreach (var obj in host.getCreatures())
            {
                if (host.isAlive(obj) && !host.isStealth(obj) && bestDist > host.me.dist(obj) && farmZone.ObjInZone(obj) && (farmMobsIds.Contains(obj.creatureId) || obj.aggroTarget == host.me) && (host.lastAttacker(obj) == null || obj.aggroTarget == host.me) && (host.me.Z - obj.Z < 15))
                {
                    bestDist = host.me.dist(obj);
                    bestMob = obj;
                }
            }
            return bestMob;
        }

        private Creature GetBestAgroMob()
        {
            double bestDist = 999999;
            Creature bestMob = null;
            foreach (var obj in host.getCreatures())
            {
                if (host.isAlive(obj) && bestDist > host.me.dist(obj) && !host.isSpellImmune(obj) && obj.aggroTarget != null && (obj.aggroTarget == host.me || obj.aggroTarget == host.getMount()) && (host.me.Z - obj.Z < 15))
                {
                    bestDist = host.me.dist(obj);
                    bestMob = obj;
                }
            }
            return bestMob;
        }
    }
}
