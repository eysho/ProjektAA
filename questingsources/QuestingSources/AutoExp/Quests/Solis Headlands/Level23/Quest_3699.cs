using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3699 : Quest
    {
        public Quest_3699(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3699, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Hanun")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(793))
                return false;
            if (!checkQuestCompletedOrPerfomed(1682))
                return false;
            if (!checkQuestCompletedOrPerfomed(788))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(15006.43, 8206.61, 3);
                if (!host.movementModule.GpsMove("Quest_3699_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 10355, 10358, 10359, 10360 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(793))
                return false;
            if (!checkQuestCompletedOrPerfomed(1682))
                return false;
            if (!checkQuestCompletedOrPerfomed(788))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Hanun"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
