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
    internal class Quest_1433 : Quest
    {
        public Quest_1433(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1433, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Megana")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1436))
                return false;
            if (!checkQuestCompletedOrAccepted(6353))
                return false;
            

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23191.90, 8733.62, 100);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("FerreLvl10_13_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 4194, 4193, 4190, 4191, 4192, 4195, 4196 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1436))
                return false;
            if (!checkQuestCompletedOrPerfomed(6353))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Megana")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
