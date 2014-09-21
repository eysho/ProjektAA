using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_886 : Quest
    {
        public Quest_886(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(886, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Sehaat")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(19151.50, 7841.40, 12);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Mahadevi_Sehaat")) return false;
                host.farmModule.SetFarmMobsFromDoodads(zone, new uint[] { 2513 }, new uint[] { 1452 });
                while (host.farmModule.farmState == Modules.FarmState.DoodadsAndMobs && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Sehaat")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
