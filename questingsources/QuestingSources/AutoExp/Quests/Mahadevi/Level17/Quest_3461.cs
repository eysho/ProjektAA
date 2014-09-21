using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3461 : Quest
    {
        public Quest_3461(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3461, minLvl, maxLvl, race, reqQuests)
        { }

        private Creature getNearest()
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if ((creature.creatureId == 10655 || creature.creatureId == 2633) && host.isAlive(creature))
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
                if (!host.movementModule.GpsMove("Mahadevi_Ungata")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(19025.20, 8755.36, 25);
                if (!host.movementModule.GpsMove("Mahadevi_Souleye")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10655, 2633 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && getNearest() != null)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
                host.UseDoodadSkill(16805, host.getNearestDoodad(10492), true);
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Eltere2")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(10000);
            }
            
            return true;
        }
    }
}
