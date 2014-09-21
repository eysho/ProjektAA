using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3491 : Quest
    {
        public Quest_3491(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3491, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Valdomero")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_3491_1")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(2627));
                Thread.Sleep(1000);
                if (!host.movementModule.GpsMove("Quest_3491_3")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(2653));
                Thread.Sleep(1000);
                if (!host.movementModule.GpsMove("Quest_3491_5")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(2652));
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Valdomero")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
