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
    internal class Quest_1852 : Quest
    {
        public Quest_1852(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1852, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (host.me != null && host.me.charGender != CharGender.Female)
                return false;

            if (!base.RunQuest(host))
                return false;


            if (getQuest() == null)
            {
                if (!(checkQuestAccepted(849) || checkQuestAccepted(811)))
                    return false;
                if (!host.movementModule.GpsMove("Singland_Mei")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(825))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1852_1")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(11636, host.getNearestDoodad(1443), true);
                Thread.Sleep(1000);
                
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Signland_Hao")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
