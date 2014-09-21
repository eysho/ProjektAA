using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1686 : Quest
    {
        public Quest_1686(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1686, minLvl, maxLvl, race, reqQuests)
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

            if (!checkQuestCompleted(3310))
                return false;
            if (!checkQuestCompleted(3309))
                return false;
            if (!checkQuestCompleted(4035))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Tarmillon")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id,3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
