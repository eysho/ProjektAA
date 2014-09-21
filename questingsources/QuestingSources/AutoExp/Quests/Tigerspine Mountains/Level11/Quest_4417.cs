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
    internal class Quest_4417 : Quest
    {
        public Quest_4417(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4417, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiget_BlueSalt")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(15659) < 1)
                {
                    if (!host.movementModule.GpsMove("Tiger_BlueSaltWell")) return false;
                    Thread.Sleep(1000);
                    host.BuyItems(15659, 1);
                    Thread.Sleep(1000);
                }
                if (host.itemCount(15659) >= 1)
                {
                    if (!host.movementModule.GpsMove("Tiger_BlueSaltFarm")) return false;
                    Thread.Sleep(1000);
                    RoundZone zone = new RoundZone(host.me.X, host.me.Y, 10);
                    host.PlantItemsInZone(15659, zone, 1);
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiget_BlueSalt")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
