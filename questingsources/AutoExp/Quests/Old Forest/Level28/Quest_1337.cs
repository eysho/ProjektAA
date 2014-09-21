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
    internal class Quest_1337 : Quest
    {
        public Quest_1337(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1337, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1340))
                return false;
            if (!checkQuestCompletedOrAccepted(1338))
                return false;
            if (!checkQuestCompletedOrAccepted(2695))
                return false;
            if (!checkQuestCompletedOrAccepted(1331))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23737.08, 11381.15, 50);
                if (!host.movementModule.GpsMove("Quest_1337_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 4724 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1340))
                return false;
            if (!checkQuestCompletedOrPerfomed(1338))
                return false;
            if (!checkQuestCompletedOrPerfomed(2695))
                return false;
            if (!checkQuestCompletedOrPerfomed(1331))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Piter")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
