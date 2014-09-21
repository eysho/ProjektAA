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
    internal class Quest_810 : Quest
    {
        public Quest_810(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(810, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLand_Saburo")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(801))
                return false;
            if (!checkQuestCompletedOrAccepted(809))
                return false;
            if (!checkQuestCompletedOrAccepted(813))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20731.82, 10311.67, 80);
                if (!host.movementModule.GpsMove("Quest_810_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5004 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(801))
                return false;
            if (!checkQuestCompletedOrPerfomed(809))
                return false;
            if (!checkQuestCompletedOrPerfomed(813))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("SigningLand_Saburo")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
