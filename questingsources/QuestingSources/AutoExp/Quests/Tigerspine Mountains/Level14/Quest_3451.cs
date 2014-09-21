using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3451 : Quest
    {
        public Quest_3451(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3451, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Bijou")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_3451_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(16796, host.getNearestDoodad(10480), true);
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Eltere")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(10000);
            }
            

            return true;
        }
    }
}
