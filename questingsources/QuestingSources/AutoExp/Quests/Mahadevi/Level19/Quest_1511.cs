using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1511 : Quest
    {
        public Quest_1511(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1511, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(1512))
                return false;
            if (!checkQuestCompletedOrAccepted(899))
                return false;
            if (!checkQuestCompletedOrAccepted(1510))
                return false;
            if (!checkQuestCompletedOrAccepted(1514))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Mikki")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(18614.10, 9458.48, 40);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_1511_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 6622, 6625 });
                while (host.farmModule.farmState == Modules.FarmState.Doodads && quest.status == QuestStatus.Accepted)
                {
                    if (host.itemCount(14394) > 0)
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 6625 });
                    if (host.itemCount(17028) > 0)
                        host.farmModule.SetFarmDoodads(zone, new uint[] { 6622 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Mikki")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
