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
    internal class Quest_3437 : Quest
    {
        public Quest_3437(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3437, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Talik"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Ferre_3437_1"))
                    return false;
                Thread.Sleep(1000);
                host.UseDoodadSkill(26176, host.getNearestDoodad(22355), true);
                Thread.Sleep(20000);
                while (!host.movementModule.GpsMove("Ferre_Eshhan"))
                {
                    if (!host.me.isAlive())
                        break;
                    return false;
                }
                Thread.Sleep(2000);
                host.TalkWithQuestNpc(id);
            }

            return true;
        }
    }
}
