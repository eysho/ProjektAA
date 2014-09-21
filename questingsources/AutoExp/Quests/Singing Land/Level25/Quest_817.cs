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
    internal class Quest_817 : Quest
    {
        public Quest_817(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(817, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Kan")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(836))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21698.99, 10142.02, 50);
                if (!host.movementModule.GpsMove("Quest_817_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5009 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                {
                    var s = host.getNearestDoodad(1444);
                    if (s != null && host.dist(s) < 10)
                    {
                        host.farmModule.StopFarm();
                        host.UseDoodadSkill(11480, s, true);
                        host.farmModule.SetFarmMobs(zone, new uint[] { 5009 });
                    }
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Singland_Kan"))
                    return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
