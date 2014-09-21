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
    internal class Quest_1241 : Quest
    {
        public Quest_1241(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(1241, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (checkQuestCompleted(3439))
                return true;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Gynnash"))
                    return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }


            if (!checkQuestCompletedOrAccepted(3438))
                return false;
            if (!checkQuestCompletedOrAccepted(1236))
                return false;
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(24411.72, 8590.32, 50);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Ferre_Shoihota"))
                        return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 4182, 4180, 4181 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
