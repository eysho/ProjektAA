using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3309 : Quest
    {
        public Quest_3309(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3309, minLvl, maxLvl, race, reqQuests)
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

            if (!checkQuestCompletedOrAccepted(3310))
                return false;
            if (!checkQuestCompletedOrAccepted(4035))
                return false;


            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.SwimUp(true);
                Zone zone = new RoundZone(18971.71, 7657.51, 65);
                if (!host.movementModule.GpsMove("Quest_3309_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 9198 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
                host.SwimUp(false);
            }

            if (!checkQuestCompletedOrPerfomed(3310))
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
