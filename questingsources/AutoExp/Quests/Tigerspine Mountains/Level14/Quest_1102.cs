using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1102 : Quest
    {
        public Quest_1102(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1102, minLvl, maxLvl, race, reqQuests)
        { }

        private Creature getNearestMob(Zone zone)
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == 3364 && host.isAlive(creature) && zone.ObjInZone(creature))
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
                if (!host.movementModule.GpsMove("Tiger_Suryan")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1092_1")) return false;
                Thread.Sleep(1000);
                Zone zone = new RoundZone(21312.21, 8676.53, 70);
                while (quest.status == QuestStatus.Accepted && host.me.isAlive())
                {
                    var m = getNearestMob(zone);
                    if (m != null)
                    {
                        host.SetTarget(m);
                        Thread.Sleep(500);
                        host.UseItem(13965, true);
                        Thread.Sleep(1000);
                        while (host.me.isAlive() && host.farmModule.aggroMobsCount() > 0)
                            Thread.Sleep(100);
                        Thread.Sleep(4000);
                        host.TalkWithQuestNpc(id);
                    }
                }
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Suryan")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
