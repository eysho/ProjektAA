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
    internal class Quest_819 : Quest
    {
        public Quest_819(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(819, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Signland_Hao")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(820))
                return false;
            //if (!checkQuestCompleted(1227))
                //return false;
            if (!checkQuestCompletedOrPerfomed(1876))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21712.39, 10526.73, 60);
                if (!host.movementModule.GpsMove("Quest_1876_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5113, 5112 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1876))
                return false;
            if (!checkQuestCompletedOrPerfomed(820))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Signland_Hao"))
                    return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id, 3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
