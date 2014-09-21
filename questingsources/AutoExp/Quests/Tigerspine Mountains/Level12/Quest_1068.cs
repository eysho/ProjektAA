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
    internal class Quest_1068 : Quest
    {
        public Quest_1068(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1068, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            var q6031 = getQuest(6031);
            if (q6031 != null && q6031.status == QuestStatus.Accepted && host.itemCooldown(8343) >= 5 && host.itemCooldown(8327) >= 3)
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Tristen")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Hadi")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            return true;
        }
    }
}
