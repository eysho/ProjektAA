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
    internal class Quest_950 : Quest
    {
        public Quest_950(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(950, minLvl, maxLvl, race, reqQuests)
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
                if (!host.movementModule.GpsMove("Quest_950_1")) return false;
                Thread.Sleep(1000);
                host.MoveTo(17120.64, 8366.42, 192.6);
                Thread.Sleep(700);
                host.MoveTo(17124.54, 8354.99, 195.75);
                Thread.Sleep(1000);
                if (Math.Abs(host.me.Z - 195.74) < 0.5)
                {
                    var m = host.farmModule.GetNearestCreatureById(3071);
                    if (m != null)
                    {
                        host.SetTarget(m);
                        Thread.Sleep(500);
                        host.UseItem(8166);
                        Thread.Sleep(500);
                    }
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
