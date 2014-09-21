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
    internal class Quest_1492 : Quest
    {
        public Quest_1492(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1492, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Verjin"))
                    return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.UseItemAndWait(14321);
                Thread.Sleep(500);
                host.UseItemAndWait(14403);
                Thread.Sleep(500);
                host.UseItemAndWait(23620);
                Thread.Sleep(500);
                if (!host.movementModule.GpsMove("Quest_1492_1"))
                    return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(13694, host.getNearestDoodad(3203), true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Verjin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
