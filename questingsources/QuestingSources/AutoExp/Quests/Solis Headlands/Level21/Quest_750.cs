using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_750 : Quest
    {
        public Quest_750(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(750, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Lamamorti")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(765))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(17153.01, 7342.73, 120);
                if (!host.movementModule.GpsMove("Quest_750_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2908 }, 5080);
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3707))
                return false;
                        
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Lamamorti")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id, 3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
