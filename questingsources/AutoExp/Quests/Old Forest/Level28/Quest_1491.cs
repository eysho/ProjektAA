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
    internal class Quest_1491 : Quest
    {
        public Quest_1491(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1491, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_BenAdjara")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(3483))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1491_1")) return false;
                Thread.Sleep(1000);
                host.UseItemAndWait(14318);
                Thread.Sleep(1000);
                host.UseItemAndWait(14319);
                Thread.Sleep(2000);
                host.TalkWithQuestNpc(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
