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
    internal class Quest_1316 : Quest
    {
        public Quest_1316(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1316, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                var c = host.farmModule.GetNearestCreatureById(3141);
                if (c == null || (c != null && host.dist(c) > 3))
                {
                    if (!host.movementModule.GpsMove("OldForest_Silvia")) return false;
                    Thread.Sleep(1000);
                    host.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1000);
                    host.ClimbUp();
                    Thread.Sleep(1000);
                }
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(1314))
                return false;
            if (!checkQuestCompletedOrPerfomed(2559))
                return false;
            if (!checkQuestCompletedOrPerfomed(1329))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22829.75, 11723.96, 20);
                if (!host.movementModule.GpsMove("Quest_1316_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 2582 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Xranitel")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
                
            }


            
            

            return true;
        }
    }
}
