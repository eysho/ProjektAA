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
    internal class Quest_1565 : Quest
    {
        public Quest_1565(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1565, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(3440))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Murana")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Ferre_Murana")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(15461, host.getNearestDoodad(14049), true, 3);
                host.UseDoodadSkill(15461, host.getNearestDoodad(6435), true, 3);
                host.UseDoodadSkill(15461, host.getNearestDoodad(14050), true, 3);
                Thread.Sleep(1000);
            }


            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Murana")) return false;
                host.CompleteQuest(id, 1);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
