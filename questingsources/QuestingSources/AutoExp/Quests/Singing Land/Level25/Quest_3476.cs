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
    internal class Quest_3476 : Quest
    {
        public Quest_3476(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3476, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLand_Narine")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("SigningLand_Grel")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                Thread.Sleep(60000);
                if (!host.movementModule.GpsMove("SigningLand_Grel2")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(10000);
            }

            return true;
        }
    }
}
