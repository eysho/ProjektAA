using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_777 : Quest
    {
        public Quest_777(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(777, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Sanjei")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(3692))
                return false;
            if (!checkQuestCompletedOrAccepted(776))
                return false;
            if (!checkQuestCompletedOrPerfomed(3693))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new PolygonZone(new List<ZonePoint>() { new ZonePoint(15500.86, 7859.39), new ZonePoint(15479.40, 7829.57), new ZonePoint(15411.91, 7842.26), new ZonePoint(15439.93, 7882.85), new ZonePoint(15458.45, 7932.70), new ZonePoint(15522.39, 7913.75) });
                if (!host.movementModule.GpsMove("Quest_777_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 7509 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(792))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Sanjei"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
