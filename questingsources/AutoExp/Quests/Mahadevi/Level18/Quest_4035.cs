using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_4035 : Quest
    {
        public Quest_4035(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4035, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Harban")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(3310))
                return false;
            if (!checkQuestCompletedOrAccepted(3309))
                return false;


            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_4035_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(17296, host.getNearestDoodad(11005), true);
            }

            if (!checkQuestCompletedOrPerfomed(3310))
                return false;
            if (!checkQuestCompletedOrPerfomed(3309))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Harban")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
