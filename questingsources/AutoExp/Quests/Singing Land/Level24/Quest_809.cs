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
    internal class Quest_809 : Quest
    {
        public Quest_809(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(809, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLand_Saburo")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(801))
                return false;
            if (!checkQuestCompletedOrAccepted(813))
                return false;
            if (!checkQuestCompletedOrPerfomed(810))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new PolygonZone(new List<ZonePoint>() { new ZonePoint(20612.07, 10305.06), new ZonePoint(20610.93, 10282.36), new ZonePoint(20585.49, 10290.08), new ZonePoint(20565.31, 10295.87), new ZonePoint(20571.01, 10304.53), new ZonePoint(20582.04, 10308.52) });
                if (!host.movementModule.GpsMove("Quest_809_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5001, 5000, 5080 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(801))
                return false;
            if (!checkQuestCompletedOrPerfomed(813))
                return false;
            if (!checkQuestCompletedOrPerfomed(810))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("SigningLand_Saburo")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
