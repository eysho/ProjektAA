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
    internal class Quest_1303 : Quest
    {
        public Quest_1303(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1303, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Andersen")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1305))
                return false;

            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22207.77, 11556.01, 20);
                if (!host.movementModule.GpsMove("Quest_1303_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 2761 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted && host.farmModule.getDoodadsCountInZone(zone, 2761) > 0)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);

                if (quest.status == QuestStatus.Accepted && host.isAlive())
                {
                    zone = new RoundZone(22319.67, 11612.86, 15);
                    if (!host.movementModule.GpsMove("Quest_1303_2"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 2761 });
                    while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted && host.farmModule.getDoodadsCountInZone(zone, 2761) > 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }

                if (quest.status == QuestStatus.Accepted && host.isAlive())
                {
                    zone = new RoundZone(22280.72, 11760.30, 50);
                    if (!host.movementModule.GpsMove("Quest_1303_3"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 2761 });
                    while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted && host.farmModule.getDoodadsCountInZone(zone, 2761) > 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompletedOrPerfomed(1305))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Andersen")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
