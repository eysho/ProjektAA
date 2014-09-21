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
    internal class Quest_2048 : Quest
    {
        public Quest_2048(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2048, minLvl, maxLvl, race, reqQuests)
        { }

        private int mobsCountInZone(Zone zone, uint[] ids)
        { 
            int result = 0;
            foreach (var m in host.getCreatures())
            {
                if (ids.Contains(m.creatureId) && zone.ObjInZone(m))
                    result++;
            }
            return result;
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Reiberk")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(1491))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[1] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2048_2"))
                        return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(13683, host.getNearestDoodad(5210), true);
                    Thread.Sleep(1000);
                    host.StartQuest(3908);
                    Thread.Sleep(1000);
                }
                if (quest.steps[0] == 0)
                {
                    Zone zone = new RoundZone(23361.49, 11339.23, 10);
                    if (!host.movementModule.GpsMove("Quest_2048_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 3110, 3126 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[0] == 0 && quest.status == QuestStatus.Accepted && mobsCountInZone(zone, new uint[] { 3110, 3126 }) > 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(13683, host.getNearestDoodad(5207), true);
                    Thread.Sleep(1000);
                }
                if (quest.steps[2] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_2048_3"))
                        return false;
                    Thread.Sleep(1000);
                    host.UseDoodadSkill(13683, host.getNearestDoodad(5213), true);
                    Thread.Sleep(1000);
                    host.StartQuest(3908);
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompleted(2051))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Reiberk")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
