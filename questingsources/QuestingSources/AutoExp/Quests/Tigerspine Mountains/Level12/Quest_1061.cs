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
    internal class Quest_1061 : Quest
    {
        public Quest_1061(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1061, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Dahir")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();


            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1061_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(11953, host.getNearestDoodad(2273), true);
                Thread.Sleep(15000);
            }
            
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Dahir")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id, 3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
