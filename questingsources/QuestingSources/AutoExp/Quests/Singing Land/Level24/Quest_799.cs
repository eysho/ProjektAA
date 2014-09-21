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
    internal class Quest_799 : Quest
    {
        public Quest_799(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(799, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLand_Shao")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("SigningLand_Shao")) return false;
                Thread.Sleep(1000);
                var c = host.farmModule.GetNearestCreatureById(5038);
                if (c != null)
                {
                    host.SetTarget(c);
                    Thread.Sleep(500);
                    host.UseItemAndWait(5116);
                    Thread.Sleep(4000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("SigningLand_Shao")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
