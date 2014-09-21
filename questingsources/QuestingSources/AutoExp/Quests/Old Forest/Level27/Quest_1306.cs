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
    internal class Quest_1306 : Quest
    {
        public Quest_1306(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1306, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Blekli")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(2060))
                return false;
            if (!checkQuestCompletedOrPerfomed(1307))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22700.37, 12421.95, 60);
                if (!host.movementModule.GpsMove("Quest_1306_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3133, 3132 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Blekli")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id,1);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
