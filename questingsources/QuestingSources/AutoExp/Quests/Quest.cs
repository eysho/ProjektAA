using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal enum QuestRace
    { 
        Nuian,
        Elf,
        Ferre,
        Hariharan,
        All
    }

    internal class Quest
    {
        protected uint id = 0;
        protected int minLvl = 0;
        protected int maxLvl = 0;
        protected QuestRace race = QuestRace.All;
        protected uint[] reqQuests = new uint[0];
        protected uint[] reqUncompleteQuests = null;
        protected Host host;
        protected string name;

        public Quest(uint id, int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests = null)
        {
            this.id = id;
            this.minLvl = minLvl;
            this.maxLvl = maxLvl;
            this.race = race;
            this.reqQuests = reqQuests;
            this.reqUncompleteQuests = reqUncompleteQuests;
            name = "";
        }

        public virtual bool RunQuest(Host host)
        {
            this.host = host;
            
            //if (host.me.level < minLvl || host.me.level > maxLvl)
                //return false;
            if (host.getCompletedQuest(id) != null) //already done
                return false;
            if (race == QuestRace.Nuian && host.me.charRace != ArcheBuddy.Bot.Classes.CharRace.Nuian)
                return false;
            if (race == QuestRace.Elf && host.me.charRace != ArcheBuddy.Bot.Classes.CharRace.Elf)
                return false;
            if (race == QuestRace.Ferre && host.me.charRace != ArcheBuddy.Bot.Classes.CharRace.Ferre)
                return false;
            if (race == QuestRace.Hariharan && host.me.charRace != ArcheBuddy.Bot.Classes.CharRace.Hariharan)
                return false;

            if (reqUncompleteQuests != null)
            {
                for (int i = 0; i < reqUncompleteQuests.Length; i++)
                {
                    if (checkQuestCompleted(reqUncompleteQuests[i]))
                        return false;
                }
            }

            List<uint> reqQuestList = reqQuests.ToList();
            foreach (var q in host.getCompletedQuests())
            {
                if (q.id == id)
                    return false;
                if (reqQuestList.Contains(q.id))
                    reqQuestList.Remove(q.id);
            }
            if (reqQuestList.Count > 0)
                return false;

            if (host.sqlCore.sqlQuestContexts.ContainsKey(id))
                host.mainForm.SetQuestModuleText(host.sqlCore.sqlQuestContexts[id].name + "[" + id + "]");
            return true;
        }

        protected ArcheBuddy.Bot.Classes.Quest getQuest()
        {
            return host.getQuest(id);
        }

        protected ArcheBuddy.Bot.Classes.Quest getQuest(uint id)
        {
            return host.getQuest(id);
        }

        protected bool checkQuestCompleted(uint id)
        {
            return host.getCompletedQuest(id) != null;
        }

        protected bool checkQuestAccepted(uint id)
        {
            return host.getQuest(id) != null && host.getQuest(id).status == QuestStatus.Accepted;
        }

        protected bool checkQuestCompletedOrAccepted(uint id)
        {
            return (host.getCompletedQuest(id) != null || host.getQuest(id) != null);
        }

        protected bool checkQuestCompletedOrPerfomed(uint id)
        {
            var q = host.getQuest(id);
            return (host.getCompletedQuest(id) != null || (q != null && q.status == QuestStatus.Performed));
        }

        protected DoodadObject getMyDoodadById(uint id)
        {
            double dist = 999999;
            DoodadObject doodad = null;
            foreach (var d in host.getDoodads())
            {
                if (d.uniqOwnerId == host.me.uniqId && host.me.dist(d) < dist && d.dbFuncGroup.id == id)
                {
                    dist = host.me.dist(d);
                    doodad = d;
                }
            }
            if (doodad != null)
            {
                return doodad;
            }
            return null;
        }
    }
}
