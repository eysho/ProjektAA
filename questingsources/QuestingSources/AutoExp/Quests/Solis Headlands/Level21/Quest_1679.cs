using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1679 : Quest
    {
        public Quest_1679(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1679, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Nessalam")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(17432.81, 8075.12, 50);
                if (!host.movementModule.GpsMove("Quest_1679_1")) return false;

                if (host.itemCount(14864) < 5)
                {
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2960 }, 15565);
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted && host.itemCount(14864) < 5)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }

                if (host.itemCount(14864) >= 5)
                {
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 7425 });
                    while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Nessalam")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
