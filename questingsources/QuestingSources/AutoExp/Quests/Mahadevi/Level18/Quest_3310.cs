using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3310 : Quest
    {
        public Quest_3310(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3310, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Jorban")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(3309))
                return false;
            if (!checkQuestCompletedOrAccepted(4035))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(18946.68, 7698.69, 30);
                if (!host.movementModule.GpsMove("Quest_3310_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 9106 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                if (!host.movementModule.GpsMove("Quest_3310_1")) return false;
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(3309))
                return false;
            if (!checkQuestCompletedOrPerfomed(4035))
                return false;


            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Jorban")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
