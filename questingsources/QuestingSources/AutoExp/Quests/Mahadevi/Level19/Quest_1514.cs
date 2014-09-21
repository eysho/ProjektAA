using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1514 : Quest
    {
        public Quest_1514(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1514, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Mahamuti")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(1691))
                return false;

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1514_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(12881, host.getNearestDoodad(4227), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1510))
                return false;
            if (!checkQuestCompletedOrPerfomed(1512))
                return false;
            if (!checkQuestCompletedOrPerfomed(899))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Mahamuti")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
