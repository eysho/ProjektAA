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
    internal class Quest_963 : Quest
    {
        public Quest_963(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(963, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Leisan")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(1415))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_963_1")) return false;
                Thread.Sleep(1000);
                Zone zone = new RoundZone(22852.91, 10853.25,9);
                if (host.itemCount(5140) < 3)
                {
                    host.farmModule.SetFarmMobs(zone, new uint[] { 5019 }, 5142);
                    while (host.me.isAlive() && quest.status == QuestStatus.Accepted && host.itemCount(5140) < 3)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                }
                if (host.itemCount(5140) >= 3)
                {
                    while (host.me.isAlive() && quest.status == QuestStatus.Accepted && host.itemCount(5140) > 0)
                    {
                        var c = host.farmModule.GetNearestCreatureById(5072);
                        if (c != null && zone.ObjInZone(c) && host.getBuff(c,1439) != null)
                        {
                            host.SetTarget(c);
                            Thread.Sleep(500);
                            host.UseItem(5140);
                        }
                        Thread.Sleep(100);
                    }
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Singland_Leisan"))
                    return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
