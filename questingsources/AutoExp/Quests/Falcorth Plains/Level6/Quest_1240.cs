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
    internal class Quest_1240 : Quest
    {
        public Quest_1240(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1240, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Gynnash"))
                    return false;
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

            ArcheBuddy.Bot.Classes.Quest qFerreLvl7_4 = getQuest(1239);
            if (qFerreLvl7_4 == null)
                return false;
            if (qFerreLvl7_4.status != QuestStatus.Performed)
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Gynnash"))
                    return false;
                host.CompleteQuest(id,1);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
