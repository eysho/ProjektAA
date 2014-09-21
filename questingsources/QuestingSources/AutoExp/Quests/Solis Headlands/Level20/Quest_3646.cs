using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3646 : Quest
    {
        public Quest_3646(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3646, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Sidur")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_3646_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(16337, host.getNearestDoodad(9786), true);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
