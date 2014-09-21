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
    internal class Quest_1365 : Quest
    {
        public Quest_1365(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1365, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Sheodar")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(1366))
                return false;
            if (!checkQuestCompletedOrPerfomed(1367))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23875.12, 9346.01, 50);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("FerreLvl8_10_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 6453 }, 3);
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
                double dist = 999999;
                Creature t = null;
                foreach (var c in host.getCreatures())
                {
                    if (c.creatureId == 11120 && host.isAlive(c) && host.me.dist(c) < dist)
                    {
                        dist = host.me.dist(c);
                        t = c;
                    }
                }
                if (t != null)
                    host.StartQuest(1413);
            }

            if (!checkQuestCompletedOrPerfomed(1366))
                return false;
            if (!checkQuestCompletedOrPerfomed(1367))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Sheodar")) return false;
                host.CompleteQuest(id, 2);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
