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
    internal class Quest_1856 : Quest
    {
        public Quest_1856(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1856, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Kereh")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(825))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1856_1")) return false;
                Thread.Sleep(1000);

                Zone zone = new RoundZone(22443.35, 9969.25, 15);
                while (host.isAlive() && quest.status == QuestStatus.Accepted)
                {
                    var c = host.farmModule.GetNearestCreatureById(7278);
                    if (c != null && zone.ObjInZone(c) && host.getBuff(c,1441) != null)
                    {
                        host.SetTarget(c);
                        Thread.Sleep(500);
                        host.UseItemAndWait(5215);
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(100);
                }
                
                
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Singland_Kereh")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
