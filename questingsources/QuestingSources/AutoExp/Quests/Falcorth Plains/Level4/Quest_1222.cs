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
    internal class Quest_1222 : Quest
    {
        public Quest_1222(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1222, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_MaraAvaran"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.farmModule.StopFarm();
                Zone zone = new RoundZone(24123.30, 9981.14, 10);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("FerreLvl4_2_1"))
                        return false;
                host.UseItemAndWait(14045);
                Thread.Sleep(2000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_MaraAvaran"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }


            return true;
        }
    }
}
