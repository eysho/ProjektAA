using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3692 : Quest
    {
        public Quest_3692(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3692, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Darmas")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(3693))
                return false;
            if (!checkQuestCompletedOrAccepted(776))
                return false;
            if (!checkQuestCompletedOrAccepted(777))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(15670.41, 7851.08, 60);
                if (!host.movementModule.GpsMove("Quest_3693_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 9901 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(792))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Darmas"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }


            return true;
        }
    }
}
