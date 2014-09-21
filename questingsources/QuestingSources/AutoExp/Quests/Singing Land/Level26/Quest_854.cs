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
    internal class Quest_854 : Quest
    {
        public Quest_854(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(854, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Aira")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21626.18, 11231.50, 38);
                if (!host.movementModule.GpsMove("Quest_854_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5006 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Singland_Aira")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id, 3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
