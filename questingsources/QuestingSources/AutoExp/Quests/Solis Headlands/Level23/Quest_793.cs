using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_793 : Quest
    {
        public Quest_793(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(793, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Hanun")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(1682))
                return false;
            if (!checkQuestCompletedOrAccepted(3699))
                return false;
            if (!checkQuestCompletedOrPerfomed(788))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[1] == 0)
                {
                    Zone zone = new RoundZone(15049.03, 8130.22, 25);
                    if (!host.movementModule.GpsMove("Quest_793_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2938 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[1] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (quest.steps[0] == 0)
                {
                    if (!host.movementModule.GpsMove("Quest_793_2"))
                        return false;
                    Thread.Sleep(1000);
                    var c = host.getNearestDoodad(9478);
                    if (c == null)
                        return false;
                    host.Climb(c);
                    Thread.Sleep(1000);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                    host.MoveTo(15088.83, 8176.32, 138.62);
                    Thread.Sleep(500);
                    host.MoveTo(15079.91, 8171.52, 140.02);
                    Thread.Sleep(500);
                    host.MoveTo(15070.03, 8172.57, 143.43);
                    Thread.Sleep(500);
                    Zone zone = new RoundZone(15070.35, 8173.15, 25);
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2926 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[0] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                    host.MoveTo(15070.03, 8172.57, 143.43);
                    Thread.Sleep(500);
                    host.MoveTo(15079.91, 8171.52, 140.02);
                    Thread.Sleep(500);
                    host.MoveTo(15088.83, 8176.32, 138.62);
                    Thread.Sleep(500);
                    host.MoveTo(15083.65, 8184.63, 138.44);
                    Thread.Sleep(500);
                    host.Climb(c);
                    Thread.Sleep(1000);
                    host.ClimbDown();
                    Thread.Sleep(1500);
                }
            }

            if (!checkQuestCompletedOrPerfomed(1682))
                return false;
            if (!checkQuestCompletedOrPerfomed(3699))
                return false;
            if (!checkQuestCompletedOrPerfomed(788))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Hanun"))
                    return false;
                host.CompleteQuest(id, 3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
