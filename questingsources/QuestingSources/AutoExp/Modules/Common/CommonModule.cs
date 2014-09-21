using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Modules
{
    internal class CommonModule : Module
    {
        //Коэфициенты для шмоток
        double str_coef = 0.2;
        double int_coef = 1.00;
        double dex_coef = 0.2;
        double wit_coef = 0.5;
        double con_coef = 0.4;
        double heavy_coef = 1.00;
        double light_coef = 0.8;
        double magic_coef = 0.7;
        double level_coef = 3.0;

        private List<uint> itemsToSell = new List<uint>() { 32110, 32134, 32102, 32123, 32099, 23387, 6127, 23390, 6152, 23388, 6077, 32166, 32113, 8012, 7992, 32145, 32152, 32170, 32175, 33000, 32169, 32176, 32173, 22103, 6202, 33213, 33005, 22159, 32184, 22230, 33226, 32996, 33224, 33361, 32984, 33233, 32981, 33234, 32978, 33225, 32990, 32987, 33235 };
        private List<uint> itemsToDelete = new List<uint>() { 15694, 29498, 19563, 17801, 19960, 14482, 17825, 15822, 14830, 23700, 26106, 16006, 21131, 24422 };
        private List<uint> itemsToWareHouse = new List<uint>() { 23092, 15596, 8337, 31892, 25253, 14677, 8343, 8000083, 8327, 23633, 21588, 16347, 16348, 16349, 16350, 16351, 16352, 23663};
        private List<uint> itemsToUnseal = new List<uint>() { 32458, 32463, 32462, 32464, 33116, 33117, 33307, 33310, 33493, 33496, 33609, 33612, 33777, 33780 };
        private List<uint> itemsToDisenchant = new List<uint>() { 33440, 33350, 33361, 33360, 33362, 33374, 33370, 33369, 33351, 33371, 33466, 33468, 33467, 33439, 22132, 22763 };
          

        private List<uint> passiveBuffsToLearn;
        private List<uint> activeSkillsToLearn;
        private List<uint> abilitiesToLearn;
        private Random randGenerator;

        public override void Start(Host host)
        {
            base.Start(host);
            passiveBuffsToLearn = new List<uint>()
            {
                15,//Mana pool increase
                38,//Magic Range Boost
                39, //Efficient Sorcery
                17, //Ясность мысли
                257, //Прилежание школяра
                37 //Колдовская мощь
            };
            activeSkillsToLearn = new List<uint>() 
            {
                10752,//Flamebolt
                10667,//Freezing arrow
                10153,//Insulating Lens
                10670,//Arc Lightning
                10151,//Обледенение

                //11379,//Mirror Light Vitalism

                10135,//Hell Spear
                11395//Призыв воронов
            };
            abilitiesToLearn = new List<uint>() { (uint)Ability.Sorcery, (uint)Ability.Songcraft, (uint)Ability.Occultism };
            randGenerator = new Random();
            foreach (var item in host.me.getItems())
            {
                host.SetVar(item, "coef", null);
            }
        }

        public void CheckSealedEquips()
        {
            if (host.isInPeaceZone()) //cant unseal in peace zone
                return;
            foreach (var i in host.me.getItems())
            {
                if (i.place != ItemPlace.Bag)
                    continue;
                if (i.id == 29203 || i.id == 29204 || i.id == 29205)
                {
                    while (i.count > 0 && host.me.opPoints > 150 && host.me.isAlive())
                    {
                        Thread.Sleep(150);
                        i.UseItem();
                        Thread.Sleep(500);
                        while (host.me.isCasting || host.me.isGlobalCooldown)
                            Thread.Sleep(50);
                    }
                }
                if (i.categoryId == 153 || itemsToUnseal.Contains(i.id)) //Unidentified or chests with closes.
                {
                    if (host.me.opPoints < 10)
                        return;
                    while (i.count > 0 && host.me.isAlive())
                    {
                        Thread.Sleep(500);
                        i.UseItem();
                        Thread.Sleep(1000);
                        while (host.me.isCasting || host.me.isGlobalCooldown)
                            Thread.Sleep(50);
                    }
                }
            }
        }

        private Creature GetWareHouseManager()
        {
            double minDist = 999999;
            Creature best = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.db.banker)
                //if (creature.db.id == 8560)
                {
                    if (minDist > host.me.dist(creature))
                    {
                        minDist = host.me.dist(creature);
                        best = creature;
                    }
                }

            }
            return best;
        }

        public void OldForestSellTrashItems()
        {
            try
            {
                RunRoute();
                if (!host.movementModule.GpsMove("OldForest_Magaz")) return;
                Thread.Sleep(1000);
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToSell.Exists(s => s == i.id))
                    {
                        if (!i.SellItem())
                            host.Log("Fail sell item " + i.name);
                        Thread.Sleep(500);
                    }
                    else if (i.place == ItemPlace.Bag && itemsToDelete.Exists(s => s == i.id))
                    {
                        if (!i.DeleteItem())
                            host.Log("Fail delete item " + i.name);
                        Thread.Sleep(500);
                    }
                }

                if (!host.movementModule.GpsMove("OldForest_Magaz")) return;
                Thread.Sleep(1000);
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToDisenchant.Exists(s => s == i.id))
                    {
                        if (host.me.opPoints < 100)
                            break;
                        if (host.itemCount(19812) == 0)
                        {
                            host.BuyItems(19812, 5);
                            Thread.Sleep(500);
                        }
                        if (!i.Disenchant())
                            host.Log("Fail disenchant item " + i.name);
                        Thread.Sleep(1500);
                    }
                }

                if (!host.movementModule.GpsMove("OldForest_Sklad")) return;
                Thread.Sleep(1000);
                host.SetTarget(GetWareHouseManager());
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToWareHouse.Exists(s => s == i.id))
                    {
                        if (!i.MoveItemToWh())
                            host.Log("Fail move to warehouse " + i.name);
                        Thread.Sleep(500);
                    }
                }

                
            }
            catch (Exception error)
            {
                host.Log(error.ToString());
            }
        }

        public void SigningLandSellTrashItems()
        {
            try
            {
                RunRoute();
                if (!host.movementModule.GpsMove("SigningLand_Sklad")) return;
                Thread.Sleep(1000);
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToSell.Exists(s => s == i.id))
                    {
                        if (!i.SellItem())
                            host.Log("Fail sell item " + i.name);
                        Thread.Sleep(500);
                    }
                    else if (i.place == ItemPlace.Bag && itemsToDelete.Exists(s => s == i.id))
                    {
                        if (!i.DeleteItem())
                            host.Log("Fail delete item " + i.name);
                        Thread.Sleep(500);
                    }
                }
                if (!host.movementModule.GpsMove("SigningLand_Sklad")) return;
                Thread.Sleep(1000);
                host.SetTarget(GetWareHouseManager());
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToWareHouse.Exists(s => s == i.id))
                    {
                        if (!i.MoveItemToWh())
                            host.Log("Fail move to warehouse " + i.name);
                        Thread.Sleep(500);
                    }
                }
            }
            catch (Exception error)
            {
                host.Log(error.ToString());
            }
        }

        public void MahadeviSellTrashItems()
        {
            try
            {
                RunRoute();
                if (!host.movementModule.GpsMove("Mahadevi_Malahar")) return;
                Thread.Sleep(1000);
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToSell.Exists(s => s == i.id))
                    {
                        if (!i.SellItem())
                            host.Log("Fail sell item " + i.name);
                        Thread.Sleep(500);
                    }
                    else if (i.place == ItemPlace.Bag && itemsToDelete.Exists(s => s == i.id))
                    {
                        if (!i.DeleteItem())
                            host.Log("Fail delete item " + i.name);
                        Thread.Sleep(500);
                    }
                }
                if (!host.movementModule.GpsMove("Mahadevi_Warehouse")) return;
                Thread.Sleep(1000);
                host.SetTarget(GetWareHouseManager());
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && itemsToWareHouse.Exists(s => s == i.id))
                    {
                        if (!i.MoveItemToWh())
                            host.Log("Fail move to warehouse " + i.name);
                        Thread.Sleep(500);
                    }
                }
            }
            catch (Exception error)
            {
                host.Log(error.ToString());
            }
        }

        public void RunRoute()
        {
            //Изучение умений
            foreach (var skill in host.me.getSkillsCanBeLearned())
            {
                if (skill.type == BotTypes.Buff)
                {
                    if (passiveBuffsToLearn.Contains((skill as Buff).dbPassiveBuff.id))
                    {
                        if (skill.Learn())
                            host.Log("Learn passive buff " + (skill as Buff).name);
                        Thread.Sleep(2000);
                    }
                }
                else if (skill.type == BotTypes.Skill)
                {
                    if (activeSkillsToLearn.Contains((skill as Skill).db.id))
                    {
                        if (skill.Learn())
                        {
                            host.Log("Learn skill " + (skill as Skill).name);
                            List<ActionSlot> slotsCanBeUsed = host.me.getActionSlots().FindAll(s => s.slotId >= 1 && s.slotId <= 48 && s.actionId == 0);
                            byte randCell = (byte)randGenerator.Next(0, slotsCanBeUsed.Count);
                            if (slotsCanBeUsed.Count > 0)
                            {
                                host.getSkill((skill as Skill).db.id).AddToActionPanel(slotsCanBeUsed[randCell].slotId);
                                host.Log("Move skill to panel " + (skill as Skill).name + " to cell #" + slotsCanBeUsed[randCell].slotId);
                            }
                        }
                        Thread.Sleep(2000);
                    }
                }
            }
            //Изучение классов
            int activeAbilitiesCount = host.me.getAbilities().Count(i => i.active);
            if (activeAbilitiesCount < 3)
            {
                if (host.me.level >= 5 && activeAbilitiesCount < 2)
                {
                    foreach (var a in abilitiesToLearn)
                    {
                        if (host.LearnSpecialisation((Ability)a))
                            host.Log("Learn specialization " + ((Ability)a).ToString());
                        Thread.Sleep(1000);
                    }
                }
                if (host.me.level >= 10)
                {
                    foreach (var a in abilitiesToLearn)
                    {
                        if (host.LearnSpecialisation((Ability)a))
                            host.Log("Learn specialization " + ((Ability)a).ToString());
                        Thread.Sleep(1000);
                    }
                }
            }

            //Считаем коэф шмоток.
            var tempItems = host.me.getItems();
            for (int i = 0; i < tempItems.Count; i++)
            {
                if ((tempItems[i].place == ItemPlace.Bag || tempItems[i].place == ItemPlace.Equiped) && tempItems[i].equipCell != EquipItemPlace.Unknown && host.GetVar(tempItems[i], "coef") == null)
                {
                    double result_coef = 0;
                    result_coef += tempItems[i].statStr * str_coef;
                    result_coef += tempItems[i].statInt * int_coef;
                    result_coef += tempItems[i].statDex * dex_coef;
                    result_coef += tempItems[i].statWit * wit_coef;
                    result_coef += tempItems[i].statCon * con_coef;
                    if (tempItems[i].armorType == ArmorType.Heavy)
                        result_coef += 100 * heavy_coef;
                    if (tempItems[i].armorType == ArmorType.Light)
                        result_coef += 100 * light_coef;
                    if (tempItems[i].armorType == ArmorType.Magic)
                        result_coef += 100 * magic_coef;
                    result_coef += tempItems[i].db.itemLevel * level_coef;
                    host.SetVar(tempItems[i], "coef", result_coef);
                    host.SetVar(tempItems[i], "bestToEquip", false);
                }
            }

            //Ищем лучший шмот
            Dictionary<byte, Item> equipCells = new Dictionary<byte, Item>();
            foreach (var value in Enum.GetValues(typeof(EquipItemPlace)))
            {
                equipCells.Add((byte)value, null);
            }
            double bestCoef = 0;
            double curCoef = 0;
            foreach (var item in host.me.getItems())
            {
                bestCoef = 0;
                curCoef = 0;
                if ((item.place == ItemPlace.Bag || item.place == ItemPlace.Equiped) && item.db.requirementLevel <= host.me.level)
                {
                    if (item.equipCell == EquipItemPlace.Finger || item.equipCell == EquipItemPlace.Ear || item.equipCell == EquipItemPlace.Neck ||
                        item.armorType == ArmorType.Heavy || item.armorType == ArmorType.Light || item.armorType == ArmorType.Magic ||
                        item.weaponType == WeaponType.TwoHandBluntStaff || item.weaponType == WeaponType.Bow || item.weaponType == WeaponType.TubeInstrument || item.weaponType == WeaponType.StringInstument || item.weaponType == WeaponType.PercussionInstrument)
                    {
                        if (host.GetVar(equipCells[(byte)item.equipCell], "coef") != null)
                            bestCoef = (double)host.GetVar(equipCells[(byte)item.equipCell], "coef");
                        if (host.GetVar(item, "coef") != null)
                            curCoef = (double)host.GetVar(item, "coef");
                        if (equipCells[(byte)item.equipCell] == null || (equipCells[(byte)item.equipCell] != null && bestCoef < curCoef))
                            equipCells[(byte)item.equipCell] = item;
                    }
                }
            }

            foreach (var b in equipCells.Keys.ToList())
            {
                if (equipCells[b] != null && host.GetVar(equipCells[b], "coef") != null)
                    if (equipCells[b].Equip())
                        host.Log(equipCells[b].equipCell + "  best item = " + equipCells[b].name + "   " + equipCells[b].armorType + "   " + equipCells[b].weaponType);

            }
        }


        public override void Run(CancellationToken ct)
        {
            while (true)
            {
                Thread.Sleep(30000);
                try
                {
                    base.Run(ct);
                    if (host.me.inFight)
                        continue;
                    if (!host.isAlive(host.me))
                        continue;
                    RunRoute();
                }
                catch(Exception error) {
                    host.Log(error.ToString());
                }
            }

        }
    }
}
