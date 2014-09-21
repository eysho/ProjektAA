using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_857 : Quest
    {
        public Quest_857(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(857, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(2125))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Supanya")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20289.23, 8389.60, 40);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_857_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5199, 2669 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Manshara")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id,3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
