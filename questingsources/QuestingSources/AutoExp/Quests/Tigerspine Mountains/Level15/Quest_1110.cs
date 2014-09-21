using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1110 : Quest
    {
        public Quest_1110(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1110, minLvl, maxLvl, race, reqQuests)
        { }

        private Creature getNearestMob()
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == 3368 && host.isAlive(creature))
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
                if (!host.movementModule.GpsMove("Tiger_Ubari")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1095))
                return false;

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1110_1")) return false;
                Thread.Sleep(1000);
                while (quest.status == QuestStatus.Accepted && host.me.isAlive())
                {
                    var m = getNearestMob();
                    if (m != null)
                    {
                        host.SetTarget(m);
                        Thread.Sleep(700);
                        host.UseItem(13971, true);
                        Thread.Sleep(1000);
                        host.UseDoodadSkill(13144, host.getNearestDoodad(2613), true);
                        Thread.Sleep(1000);
                    }
                }
            }

            if (!checkQuestCompletedOrPerfomed(1095))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Ubari")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
