using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3696 : Quest
    {
        public Quest_3696(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3696, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Asan")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            { 
                if (host.itemCount(19999) < 3)
                {
                    if (!host.movementModule.GpsMove("Quest_3696_1")) return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(16451, host.getNearestDoodad(9911), true);
                    Thread.Sleep(1000);
                }
                if (host.itemCount(19999) >= 3)
                {
                    Zone zone = new RoundZone(15768.11, 7830.50, 50);
                    if (!host.movementModule.GpsMove("Headlands_Asan")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 9908 });
                    while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Asan"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
