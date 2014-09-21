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
    internal class Quest_1317 : Quest
    {
        public Quest_1317(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1317, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Xranitel")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1316_1")) return false;
                Thread.Sleep(1000);
                host.MoveTo(22828.28, 11711.28, 269.05);
                Thread.Sleep(1000);
                host.MoveTo(host.me.X + new Random().Next(0, 4), host.me.Y + new Random().Next(0, 4), host.me.Z);
                Thread.Sleep(1000);
                host.UseItemAndWait(14112);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Xranitel")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            return true;
        }
    }
}
