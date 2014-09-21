using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1691 : Quest
    {
        public Quest_1691(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1691, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Mikki")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Mikki")) return false;
                Thread.Sleep(1000);
                var c = host.farmModule.GetNearestCreatureById(2640);
                if (c != null)
                {
                    host.SetTarget(c);
                    Thread.Sleep(500);
                    host.UseItem(14393, true);
                    Thread.Sleep(500);
                }
            }
            
            return true;
        }
    }
}
