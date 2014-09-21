using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1682 : Quest
    {
        public Quest_1682(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1682, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Hanun")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(793))
                return false;
            if (!checkQuestCompletedOrAccepted(3699))
                return false;
            if (!checkQuestCompletedOrPerfomed(788))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1682_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(12929, host.getNearestDoodad(3856), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(793))
                return false;
            if (!checkQuestCompletedOrPerfomed(3699))
                return false;
            if (!checkQuestCompletedOrPerfomed(788))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Hanun"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
