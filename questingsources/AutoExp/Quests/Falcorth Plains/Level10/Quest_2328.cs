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
    internal class Quest_2328 : Quest
    {
        public Quest_2328(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2328, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_KoiCaster")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(1438))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Ferre_Shaena")) return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(19199, host.getNearestDoodad(2753), true);
                Thread.Sleep(23000);
                if (host.me.isSwim)
                {
                    if (!host.movementModule.GpsMove("FerreLvl10_3_1")) return false;
                    Zone zone = new RoundZone(22850.53, 9442.76, 10);
                    host.farmModule.SetFarmMobs(zone, new uint[] { 4227 });
                    while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompletedOrPerfomed(1438))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_KoiCaster")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
