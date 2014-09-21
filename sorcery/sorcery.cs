using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ArcheBuddy.Bot.Classes;

namespace YourNamespace
{
    public class YourClass : Core
    {
        public static string GetPluginAuthor()
        {
            return "ArcheBuddy";
        }

        public static string GetPluginVersion()
        {
            return "1.0";
        }

        public static string GetPluginDescription()
        {
            return "Simple mobs farm";
        }
        
        //Try to find best mob in farm zone.
        public Creature GetBestNearestMob(Zone zone)
        {
            Creature mob = null;
            double dist = 999999;
            foreach (var obj in getCreatures())
            {      
                //If creature Npc and we can attack him and creature alive and distance to this creature less than other and creature have 100% hp or creature want to kill out character.
                if (obj.type == BotTypes.Npc && isAttackable(obj) && (obj.firstHitter == null || obj.firstHitter == me) && isAlive(obj) && me.dist(obj) < dist && zone.ObjInZone(obj)
                    && (hpp(obj) == 100 || obj.aggroTarget == me))
                {
                    mob = obj;
                    dist = me.dist(obj);
                }
            }
            return mob;
        }
        
        //Cancel skill if mob which we want to kill already attacked by another player.
        public void CancelAttacksOnAnothersMobs()
        {
            while (true)
            {
                if (me.isCasting && me.target != null && me.target.firstHitter != null && me.target.firstHitter != me)
                    CancelSkill();
                Thread.Sleep(100);
            }
        }  
        
        //Check our buffs
        public void CheckBuffs()
        {  
            if (buffTime("Hummingbird Ditty (Rank 1)") == 0 && skillCooldown("Hummingbird Ditty") == 0)
                UseSkillAndWait("Hummingbird Ditty", true);
        }
        
        public void UseSkillAndWait(string skillName, bool selfTarget = false)
        {
            //wait cooldowns first, before we try to cast skill
            while (me.isCasting || me.isGlobalCooldown)
                Thread.Sleep(50);
            if (!UseSkill(skillName, true, selfTarget))
            {
                if (me.target != null && GetLastError() == LastError.NoLineOfSight)
                {
                    //No line of sight, try come to target.
                    if (dist(me.target) <= 5)
                        ComeTo(me.target, 2);
                    else if (dist(me.target) <= 10)
                        ComeTo(me.target, 3);
                    else if (dist(me.target) < 20)
                        ComeTo(me.target, 8);
                    else
                        ComeTo(me.target, 8);
                }
            }      
            //wait cooldown again, after we start cast skill
            while (me.isCasting || me.isGlobalCooldown)
                Thread.Sleep(50);
        }


        public void PluginRun()
        {   
            new Task(() => { CancelAttacksOnAnothersMobs(); }).Start(); //Starting new thread
            RoundZone zone = new RoundZone(me.X, me.Y, 80); //Make new zone where we will farm. Its circle with center where your character stand at this moment with 80m radius.
            SetGroupStatus("autoexp", false); //Add checkbox to our character widget
            while (true)
            {   
                //If autoexp checkbox enabled in widget and our character alive
                if (GetGroupStatus("autoexp") && me.isAlive())
                {
                    CheckBuffs();
                    Creature bestMob = null;
                    //if we have enouth mp and hp, or mobs want to kill us - try to find bestMob.
                    if ((mpp() > 40 && hpp() > 75) || getAggroMobs().Count > 0)
                        bestMob = GetBestNearestMob(zone);    
                    //if mob exists
                    if (bestMob != null) 
                    {
                        try
                        {
                            //while this mob alive and our character alive and checkbox in widget enabled
                            while (bestMob != null && isAlive(bestMob) && isExists(bestMob) && GetGroupStatus("autoexp") && isAlive())
                            {      
                                //if another player attack this mob before our character.
                                if (bestMob.aggroTarget != me && bestMob.firstHitter != null && bestMob.firstHitter != me)
                                {
                                    bestMob = null;
                                    break;
                                }    
                                
                                //if we still dont attack our best mob, but another mob want to kill us
                                if (bestMob.firstHitter == null && getAggroMobs().Count > 0 && bestMob != GetBestNearestMob(zone)) 
                                    bestMob = GetBestNearestMob(zone);
                                
                                //Target our mob, if necessary
                                if (me.target != bestMob)
                                    SetTarget(bestMob);  
                                //Turn to our mob, if necessary
                                if (angle(bestMob, me) > 45 && angle(bestMob, me) < 315)
                                        TurnDirectly(bestMob);
                                
                                if (me.dist(bestMob) < 4 && isAlive(bestMob))
                                    UseSkillAndWait("Hell Spear");
                                UseSkillAndWait("Freezing Arrow");
                                for (int i=0;i<2;i++)
                                    UseSkillAndWait("Flamebolt");
                                   
                                //Small delay, do not load the processor
                                Thread.Sleep(10); 
                            }
                        
                            //Try to pickup drop from mob, if drop available
                            while (bestMob != null && !isAlive(bestMob) && isExists(bestMob) && bestMob.type == BotTypes.Npc && ((Npc)bestMob).dropAvailable && GetGroupStatus("autoexp") && isAlive())
                            {
                                if (me.dist(bestMob) > 3)
                                   ComeTo(bestMob, 1);
                                PickupAllDrop(bestMob);     
                            }
                        } 
                        catch {}
                        
                    }
                }
                //Small delay, do not load the processor
                Thread.Sleep(10);
            }
        }
    }
}
