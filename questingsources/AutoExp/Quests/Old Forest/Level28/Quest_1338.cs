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
    internal class Quest_1338 : Quest
    {
        public Quest_1338(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1338, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Piter")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(2695))
                return false;
            if (!checkQuestCompletedOrPerfomed(1340))
                return false;
            if (!checkQuestCompletedOrAccepted(1331))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23777.46, 11398.45, 50);
                if (!host.movementModule.GpsMove("Quest_1337_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3160 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2695))
                return false;
            if (!checkQuestCompletedOrPerfomed(1340))
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
