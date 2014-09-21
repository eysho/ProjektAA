using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3456 : Quest
    {
        public Quest_3456(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3456, minLvl, maxLvl, race, reqQuests)
        { }

        private Creature getNearest()
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == 9891 && host.isAlive(creature))
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
                if (!host.movementModule.GpsMove("Mahadevi_Kamona")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(2896))
                return false;

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Armah")) return false;
                Thread.Sleep(1000);
                var c = getNearest();
                if (c != null)
                {
                    host.SetTarget(c);
                    Thread.Sleep(500);
                    host.UseSkill(14486);
                    host.ExpressEmotion(0x22);
                    Thread.Sleep(1000);
                }
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Valdomero")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
