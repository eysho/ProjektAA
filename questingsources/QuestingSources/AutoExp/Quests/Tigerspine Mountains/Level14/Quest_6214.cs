using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_6214 : Quest
    {
        public Quest_6214(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(6214, minLvl, maxLvl, race, reqQuests)
        { }
               

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Panadi")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(10000);
            }
            

            return true;
        }
    }
}
