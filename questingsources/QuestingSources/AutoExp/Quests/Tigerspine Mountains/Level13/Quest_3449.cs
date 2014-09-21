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
    internal class Quest_3449 : Quest
    {
        public Quest_3449(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3449, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_UnknownBook")) return false;
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
            

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Tiger_CypressMember")) return false;
                Thread.Sleep(1000);
                while (quest.status == QuestStatus.Accepted && host.isAlive())
                {
                    host.UseDoodadSkill(16792, host.getNearestDoodad(10474), true);
                    Thread.Sleep(1000);
                    host.TalkWithQuestNpc(id);
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompleted(1075))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Tomiris")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(30000);
            }
            return true;
        }
    }
}
