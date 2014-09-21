using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3609 : Quest
    {
        public Quest_3609(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3609, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Hamba")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1517))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!checkQuestCompleted(3610))
                {
                    Console.WriteLine("1");
                    Zone zone = new RoundZone(17719.16, 8755.72, 15);
                    if (!host.movementModule.GpsMove("Quest_3609_1")) return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 9807 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted && !checkQuestCompleted(3610))
                        Thread.Sleep(100);
                }
                else
                {
                    Console.WriteLine("2");
                    Zone zone = new RoundZone(17748.01, 8737.04, 38);
                    if (!host.movementModule.GpsMove("Quest_3609_2")) return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2504 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                        Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1517))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Hamba")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
