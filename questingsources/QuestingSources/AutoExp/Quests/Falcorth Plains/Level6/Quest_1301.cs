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
    internal class Quest_1301 : Quest
    {
        public Quest_1301(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1301, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Nidjan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(24178.34, 8738.00, 50);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("FerreLvl6_6_1"))
                        return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 7952, 4179 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Nidjan"))
                    return false;
                host.CompleteQuest(id, 1);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
