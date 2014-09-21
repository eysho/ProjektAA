using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3678 : Quest
    {
        public Quest_3678(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3678, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Saromani")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1709))
                return false;
            if (!checkQuestCompletedOrAccepted(784))
                return false;
            if (!checkQuestCompletedOrAccepted(947))
                return false;
            if (!checkQuestCompletedOrPerfomed(3677))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(16155.56, 7709.34, 80);
                if (!host.movementModule.GpsMove("Quest_3677_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 9868 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1709))
                return false;
            if (!checkQuestCompletedOrPerfomed(784))
                return false;
            if (!checkQuestCompletedOrPerfomed(947))
                return false;
            if (!checkQuestCompletedOrPerfomed(3677))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Saromani"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
