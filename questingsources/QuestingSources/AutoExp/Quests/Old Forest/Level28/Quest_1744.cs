using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    //
    internal class Quest_1744 : Quest
    {
        public Quest_1744(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1744, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Djonatan"))
                    return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("OldForest_Djonatan")) return false;
                Thread.Sleep(1000);
                var c = host.farmModule.GetNearestCreatureById(3315);
                if (c != null)
                {
                    host.SetTarget(c);
                    Thread.Sleep(500);
                    host.UseItemAndWait(18428);
                    Thread.Sleep(2000);
                    Zone zone = new RoundZone(24057.10, 11471.73, 10);
                    host.farmModule.SetFarmMobs(zone, new uint[] { 3315 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted && host.farmModule.aggroMobsCount() > 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                }
                
            }

            
            return true;
        }
    }
}
