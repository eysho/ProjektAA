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
    internal class Quest_835 : Quest
    {
        public Quest_835(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(835, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Meiko")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Singland_Meiko")) return false;
                Thread.Sleep(1000);
                host.MoveTo(21461.33, 9761.68, 345.08);
                Thread.Sleep(1000);
                host.MoveTo(21455.35, 9756.89, 345.30);
                Thread.Sleep(1000);
                host.UseItemAndWait(5132);
                Thread.Sleep(1000);
                host.MoveTo(21460.55, 9747.88, 345.90);

                Zone zone = new RoundZone(21457.87, 9762.08, 20);
                host.farmModule.SetFarmMobs(zone, new uint[] { 5025 });
                while (host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted)
                {
                    bool alive = false;
                    foreach (var c in host.getCreatures())
                    {
                        if (c.creatureId == 5025)
                            alive = true;
                    }
                    if (!alive)
                        break;
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Singland_Meiko")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
