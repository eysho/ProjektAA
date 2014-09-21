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
    internal class Quest_1218 : Quest
    {
        public Quest_1218(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1218, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Kanhar"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest qFerreLvl3_2 = getQuest(1574);
            if (qFerreLvl3_2 == null)
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.UseDoodadSkill(18766, host.getNearestDoodad(13700), true);
                Thread.Sleep(25000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Kanhar"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
