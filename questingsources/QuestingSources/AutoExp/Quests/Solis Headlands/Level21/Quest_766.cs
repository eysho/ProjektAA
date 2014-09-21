using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_766 : Quest
    {
        public Quest_766(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(766, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Arhat")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(765))
                return false;
            if (!checkQuestCompletedOrAccepted(764))
                return false;
            if (!checkQuestCompletedOrAccepted(750))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_766_1")) return false;
                Thread.Sleep(1000);
                Zone zone = new RoundZone(16960.32, 7638.99, 30);
                host.farmModule.SetFarmAggros();
                while (host.isAlive() && quest.status == QuestStatus.Accepted)
                {
                    if (host.farmModule.aggroMobsCount() == 0)
                    {
                        var c = host.farmModule.GetNearestCreaturesInZoneById(zone, new List<uint> { 10116, 10169, 10171, 10168, 10117, 10170});
                        if (c != null)
                        {
                            host.SetTarget(c);
                            Thread.Sleep(500);
                            host.UseItem(18977, true);
                            Thread.Sleep(500);
                            host.UseItem(19990, true);
                            Thread.Sleep(3000);
                        }
                    }
                    Thread.Sleep(1000);
                }
                host.farmModule.StopFarm();
            }

            if (!checkQuestCompleted(3707))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Arhat")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
