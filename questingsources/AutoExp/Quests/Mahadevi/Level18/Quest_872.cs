using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_872 : Quest
    {
        public Quest_872(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(872, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Anatta")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(880))
                return false;

            if (quest.status == QuestStatus.Accepted) 
            {
                if (!host.movementModule.GpsMove("Mahadevi_Hadari")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id);
                Thread.Sleep(1000);
            }


            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Uruma")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(12900, host.getNearestDoodad(2021), true);
                Thread.Sleep(1000);
                host.MoveTo(18711.22, 8892.30, 189.44);
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
