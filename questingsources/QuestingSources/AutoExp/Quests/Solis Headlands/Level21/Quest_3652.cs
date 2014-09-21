using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3652 : Quest
    {
        public Quest_3652(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3652, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Kapur")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Headlands_Kapur")) return false;
                Thread.Sleep(1000);
                host.MoveTo(16875.53, 7970.40, 155.71);
                Thread.Sleep(1000);
                host.MoveTo(16858.15, 7980.95, 161.86);
                Thread.Sleep(500);
                host.MoveTo(16856.05, 7976.75, 161.86);
                Thread.Sleep(500);
                host.Climb(host.getNearestDoodad(30));
                Thread.Sleep(500);
                host.ClimbUp();
                Thread.Sleep(500);
                host.UseDoodadSkill(16352, host.getNearestDoodad(9800), true);
                Thread.Sleep(500);
                host.Climb(host.getNearestDoodad(30));
                Thread.Sleep(1500);
                host.ClimbDown();
                Thread.Sleep(1000);
                host.MoveTo(16856.84, 7972.61, 161.86);
                Thread.Sleep(500);
                host.MoveTo(16857.90, 7982.02, 161.86);
                Thread.Sleep(500);
                host.MoveTo(16866.74, 7975.43, 157.69);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Kapur")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
