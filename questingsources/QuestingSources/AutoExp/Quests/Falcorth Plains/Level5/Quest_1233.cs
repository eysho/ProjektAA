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
    internal class Quest_1233 : Quest
    {
        public Quest_1233(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1233, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Eshhan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (getQuest(2309) == null)
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(24431.65, 9207.56, 70);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("FerreLvl5_6_1"))
                        return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5731, 5732, 5733, 5734, 11575, 11576, 11577, 11578 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("FerreLvl5_6_1"))
                    return false;
                if (!host.movementModule.GpsMove("Ferre_Eshhan")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
