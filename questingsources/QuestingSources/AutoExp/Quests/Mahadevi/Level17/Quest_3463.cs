using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3463 : Quest
    {
        public Quest_3463(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3463, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Ritis")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(748))
                return false;
            
            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Romosa")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(10000);
            }
            
            return true;
        }
    }
}
