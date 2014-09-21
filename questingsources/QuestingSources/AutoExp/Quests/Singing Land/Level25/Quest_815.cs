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
    internal class Quest_815 : Quest
    {
        public Quest_815(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(815, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_815_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(13334, host.getNearestDoodad(1441), true);
                Thread.Sleep(2000);
            }
            

            return true;
        }
    }
}
