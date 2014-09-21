using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1507 : Quest
    {
        public Quest_1507(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1507, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Fessimar")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(18544.75, 7551.85, 60);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_1507_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5258 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                {
                    if (host.me.target != null && host.me.target.creatureId == 5258 && host.hpp(host.me.target) < 50)
                    {
                        host.farmModule.StopFarm();
                        while (host.me.isCasting || host.me.isGlobalCooldown)
                            Thread.Sleep(10);
                        host.UseItem(14380, true);
                        while (host.me.isCasting || host.me.isGlobalCooldown)
                            Thread.Sleep(10);
                        host.farmModule.SetFarmMobs(zone, new uint[] { 5258 });
                    }
                    Thread.Sleep(100);
                }
                
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Fessimar")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
