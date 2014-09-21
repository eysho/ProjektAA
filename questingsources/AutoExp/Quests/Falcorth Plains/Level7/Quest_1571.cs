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
    internal class Quest_1571 : Quest
    {
        public Quest_1571(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1571, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Henta")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("FerreLvl7_3_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(17963, host.getNearestDoodad(12120), true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Henta")) return false;
                host.CompleteQuest(id, 1);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
