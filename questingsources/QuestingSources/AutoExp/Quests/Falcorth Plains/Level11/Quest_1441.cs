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
    internal class Quest_1441 : Quest
    {
        public Quest_1441(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1441, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Megana")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1437))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23359.67, 8528.11, 100);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("FerreLvl11_1_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 6780 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1437))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Damir")) return false;
                host.CompleteQuest(id, 2);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
