using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3680 : Quest
    {
        public Quest_3680(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3680, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Tyrana")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(783))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(16325.24, 8139.72, 80);
                if (!host.movementModule.GpsMove("Quest_3680_1"))
                    return false;
                host.farmModule.SetFarmMobsFromDoodads(zone, new uint[] { 9888 }, new uint[] {9885 });
                while ((host.farmModule.farmState == Modules.FarmState.DoodadsAndMobs || host.farmModule.farmState == Modules.FarmState.Enabled) && quest.status == QuestStatus.Accepted)
                {
                    if (host.itemCount(19973) == 0)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 9888 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(783))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Tyrana"))
                    return false;
                host.CompleteQuest(id, 3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
