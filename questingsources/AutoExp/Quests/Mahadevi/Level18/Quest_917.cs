using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_917 : Quest
    {
        public Quest_917(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(917, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                var c = host.farmModule.GetNearestCreatureById(5214);
                if (c != null && host.dist(c) < 5)
                {
                    host.StartQuest(id);
                    Thread.Sleep(1000);
                }
                else
                {
                    if (!host.movementModule.GpsMove("Mahadevi_Uruma")) return false;
                    Thread.Sleep(1000);
                    while (!host.UseDoodadSkill(12900, host.getNearestDoodad(2021), true))
                        Thread.Sleep(1000);
                    host.MoveTo(18711.22, 8892.30, 189.44);
                    Thread.Sleep(1000);
                    host.StartQuest(id);
                    Thread.Sleep(1000);
                }
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                var c = host.farmModule.GetNearestCreatureById(5214);
                if (c != null && host.dist(c) < 5)
                {
                    while (!host.UseDoodadSkill(12900, host.getNearestDoodad(2021), true))
                        Thread.Sleep(1000);
                    Thread.Sleep(500);
                    host.MoveTo(18712.79, 8883.50, 190.50);
                }
                else
                {
                    if (!host.movementModule.GpsMove("Mahadevi_Uruma")) return false;
                    Thread.Sleep(1000);
                    while (!host.UseDoodadSkill(12900, host.getNearestDoodad(2021), true))
                        Thread.Sleep(1000);
                    Thread.Sleep(500);
                    host.MoveTo(18712.79, 8883.50, 190.50);
                }
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Hadari")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
