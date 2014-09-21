using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1107 : Quest
    {
        public Quest_1107(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1107, minLvl, maxLvl, race, reqQuests)
        { }

        private Creature getNearestMob(Zone zone)
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == 3366 && host.isAlive(creature) && zone.ObjInZone(creature) && host.getBuff(creature,873) == null)
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

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Ubari")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21043.37, 8748.22, 100);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_1107_1")) return false;
                while (host.me.isAlive() && quest.status == QuestStatus.Accepted)
                {
                    if (host.farmModule.aggroMobsCount() == 0)
                    {
                        var m = getNearestMob(zone);
                        if (m != null)
                        {
                            host.SetTarget(m);
                            Thread.Sleep(1000);
                            host.UseItem(14579, true);
                            Thread.Sleep(2500);
                        }
                        Thread.Sleep(1000);
                        host.UseDoodadSkill(12052, host.getNearestDoodad(3075), true);
                    }
                    else 
                    {
                        host.farmModule.SetFarmMobs(zone, new uint[] { 3366 });
                        while (host.me.isAlive() && host.farmModule.aggroMobsCount() > 0)
                            Thread.Sleep(1000);
                        host.farmModule.StopFarm();
                    }
                    Thread.Sleep(1000);
                }
                
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Ubari")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
