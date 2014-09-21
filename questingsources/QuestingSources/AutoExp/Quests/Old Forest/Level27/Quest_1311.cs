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
    internal class Quest_1311 : Quest
    {
        public Quest_1311(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1311, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Petersen")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] == 0)
                {
                    if (!host.movementModule.GpsMove("OIdForest_Brendon")) return false;
                    Thread.Sleep(1000);
                    host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(3290));
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] == 0)
                {
                    if (!host.movementModule.GpsMove("OldForest_Blekli")) return false;
                    Thread.Sleep(1000);
                    host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(3131));
                    Thread.Sleep(1000);
                }
                if (quest.steps[2] == 0)
                {
                    if (!host.movementModule.GpsMove("OldForest_Blekli")) return false;
                    Thread.Sleep(1000);
                    host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(3135));
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Petersen")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
