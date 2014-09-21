using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_792 : Quest
    {
        public Quest_792(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(792, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(3692))
                return false;
            if (!checkQuestCompletedOrPerfomed(3693))
                return false;
            if (!checkQuestCompletedOrPerfomed(777))
                return false;
            if (!checkQuestCompletedOrPerfomed(776))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Dirhan")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.UseItem(5184);
                Zone zone = new RoundZone(15270.49, 7923.41, 25);
                if (!host.movementModule.GpsMove("Quest_792_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 1847 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Dirhan"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
