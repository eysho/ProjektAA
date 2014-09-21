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
    internal class Quest_1314 : Quest
    {
        public Quest_1314(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1314, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Olderton")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1314))
                return false;
            if (!checkQuestCompletedOrPerfomed(2559))
                return false;
            if (!checkQuestCompletedOrAccepted(1329))
                return false;


            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22738.29, 11840.64, 50);
                if (!host.movementModule.GpsMove("Quest_1314_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3140 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(2559))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Olderton")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000); 
            }


            
            

            return true;
        }
    }
}
