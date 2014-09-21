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
    internal class Quest_798 : Quest
    {
        public Quest_798(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(798, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLands_Ukun")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(797))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20872.47, 10195.28, 60);
                if (!host.movementModule.GpsMove("Quest_798_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5089 }, 8118);
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(797))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("SigningLands_Ukun")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id,1);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
