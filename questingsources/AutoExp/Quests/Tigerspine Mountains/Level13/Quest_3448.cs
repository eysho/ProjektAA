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
    internal class Quest_3448 : Quest
    {
        public Quest_3448(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3448, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Taka")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1445))
                return false;
            if (!checkQuestCompletedOrAccepted(1076))
                return false;
            if (!checkQuestCompletedOrAccepted(1171))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_UnknownBook")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(30000);
            }
            return true;
        }
    }
}
