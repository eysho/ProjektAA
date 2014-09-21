using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1100 : Quest
    {
        public Quest_1100(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1100, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Nubo")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1100_1")) return false;
                Thread.Sleep(1000);
                var d = host.getNearestDoodad(2308);
                if (d != null && host.me.dist(d) < 7)
                    host.UseDoodadSkill(12905, d, true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1098))
                return false;
            if (!checkQuestCompletedOrPerfomed(1099))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Yaturaba")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
