﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1105 : Quest
    {
        public Quest_1105 (int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1105, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Yaturaba")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1096))
                return false;

            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Tiger_Krabat")) return false;
                Thread.Sleep(1000);
            }
            

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Krabat")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
