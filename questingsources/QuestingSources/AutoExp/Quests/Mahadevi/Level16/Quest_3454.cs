using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3454 : Quest
    {
        public Quest_3454(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3454, minLvl, maxLvl, race, reqQuests)
        { }

        private Creature getNearest()
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == 9889 && host.isAlive(creature))
                {
                    if (minDist > host.me.dist(creature))
                    {
                        minDist = host.me.dist(creature);
                        bestCreature = creature;
                    }
                }

            }
            return bestCreature;
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Madadevi_Kakula")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20132.60, 8586.44, 40);
                if (!host.movementModule.GpsMove("Quest_3454_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10153 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted && host.itemCount(21310) == 0)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);

                if (host.itemCount(21310) > 0)
                {
                    if (!host.movementModule.GpsMove("Madadevi_Kakula")) return false;
                    Thread.Sleep(1000);
                    var c = getNearest();
                    if (c != null)
                    {
                        host.SetTarget(c);
                        Thread.Sleep(500);
                        host.UseItem(21310, true);
                        Thread.Sleep(1000);
                    }
                }
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Madadevi_Kakula")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
