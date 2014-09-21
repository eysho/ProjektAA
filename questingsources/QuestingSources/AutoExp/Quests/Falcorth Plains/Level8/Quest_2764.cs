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
    internal class Quest_2764 : Quest
    {
        public Quest_2764(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2764, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(3440))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Murana")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.MoveTo(24033.92, 8824.24, 578.77);
                host.MoveTo(24040.92, 8843.14, 580.27);
                Thread.Sleep(500);
                host.MoveTo(24043.73, 8842.14, 580.18);
                Thread.Sleep(500);
                host.MoveTo(24044.49, 8835.07, 582.29);
                Thread.Sleep(500);
                var door = host.getNearestDoodad(11163);
                if (door != null && host.dist(door) < 3)
                {
                    host.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(1000);
                }
                host.MoveTo(24059.02, 8838.92, 582.32);
                Thread.Sleep(500);
                host.MoveTo(24056.78, 8842.97, 582.32);
                host.MoveTo(24059.02, 8838.92, 582.32);
                host.MoveTo(24048.03, 8835.72, 582.32);
                Thread.Sleep(700);
                host.MoveTo(24048.03, 8835.72, 582.32);
                Thread.Sleep(700);
                host.MoveTo(24059.02, 8838.92, 582.32);
                Thread.Sleep(700);
                host.MoveTo(24056.78, 8842.97, 582.32);
                Thread.Sleep(700);
                host.MoveTo(24059.02, 8838.92, 582.32);
                Thread.Sleep(700);
                host.MoveTo(24048.03, 8835.72, 582.32);
                Thread.Sleep(700);
                door = host.getNearestDoodad(11163);
                if (door != null && host.dist(door) < 3)
                {
                    host.UseDoodadSkill(16828, door, true);
                    Thread.Sleep(1000);
                }
                host.MoveTo(24044.49, 8835.07, 582.29);
                Thread.Sleep(700);
                host.MoveTo(24043.73, 8842.14, 580.18);
                Thread.Sleep(500);
                host.MoveTo(24040.92, 8843.14, 580.27);
                Thread.Sleep(500);
                host.MoveTo(24033.92, 8824.24, 578.77);
            }

            return true;
        }
    }
}
