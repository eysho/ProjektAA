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
    internal class Quest_949 : Quest
    {
        public Quest_949(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(949, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Bashudi")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(3646))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_949_1")) return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(12876, host.getNearestDoodad(2029), true);
                    Thread.Sleep(1000);
                }
                if (quest.steps[2] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_949_2")) return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(12879, host.getNearestDoodad(2030), true);
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_949_3")) return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(12880, host.getNearestDoodad(2042), true);
                    Thread.Sleep(1000);
                }
                if (quest.steps[3] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_949_4")) return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(12878, host.getNearestDoodad(2031), true);
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Bashudi")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
