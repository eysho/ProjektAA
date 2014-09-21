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
    internal class Quest_1490 : Quest
    {
        public Quest_1490(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1490, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_BenAdjara")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23196.79, 11682.01, 30);
                if (!host.movementModule.GpsMove("Quest_1490_1"))
                    return false;

                host.UseDoodadSkill(13693, host.getNearestDoodad(5462), true);
                Thread.Sleep(1000);
                host.UseDoodadSkill(13693, host.getNearestDoodad(2511), true);
                Thread.Sleep(1000);
                host.UseDoodadSkill(13693, host.getNearestDoodad(5465), true);
                Thread.Sleep(1000);
                
                if (host.itemCount(14527) > 0 && host.itemCount(14528) > 0 && host.itemCount(14317) > 0)
                    host.UseItemAndWait(14527);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_BenAdjara")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
