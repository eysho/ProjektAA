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
    internal class Quest_1062 : Quest
    {
        public Quest_1062(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1062, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Dahir")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1055))
                return false;
            if (!checkQuestCompletedOrAccepted(1064))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                for (int i = 1; i <= 8;i++ )
                {
                    if (quest.status == QuestStatus.Accepted)
                    {
                        if (!host.movementModule.GpsMove("Quest_1062_" + i)) return false;
                        Thread.Sleep(1000);
                        var d = host.getNearestDoodad(2275);
                        if (d != null && host.me.dist(d) < 3)
                        {
                            host.UseDoodadSkill(12055, d);
                            Thread.Sleep(1000);
                        }
                    }
                }
                for (int i = 7; i >= 1; i--)
                {
                    if (quest.status == QuestStatus.Accepted)
                    {
                        if (!host.movementModule.GpsMove("Quest_1062_" + i)) return false;
                        Thread.Sleep(1000);
                        var d = host.getNearestDoodad(2275);
                        if (d != null && host.me.dist(d) < 3)
                        {
                            host.UseDoodadSkill(12055, d);
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            if (!checkQuestCompletedOrPerfomed(1066))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Tristen")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }



            return true;
        }
    }
}
