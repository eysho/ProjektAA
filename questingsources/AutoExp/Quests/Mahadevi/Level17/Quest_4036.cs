using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_4036 : Quest
    {
        public Quest_4036(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4036, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(1686))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Harban")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Harban")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(17294, host.getNearestDoodad(10999), true);
                Thread.Sleep(1000);
            }
                        
            return true;
        }
    }
}
