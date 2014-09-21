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
    internal class Quest_1445 : Quest
    {
        public Quest_1445(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1445, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Hadi")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1076))
                return false;
            if (!checkQuestCompletedOrAccepted(1071))
                return false;
            if (!checkQuestCompletedOrAccepted(3449))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21159.82, 7953.40, 50);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_1071_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3351, 3354 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Ashrei")) return false;
                host.CompleteQuest(id, 1);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
