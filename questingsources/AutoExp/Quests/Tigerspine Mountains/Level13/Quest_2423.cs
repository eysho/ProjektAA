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
    internal class Quest_2423 : Quest
    {
        public Quest_2423 (int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2423, minLvl, maxLvl, race, reqQuests)
        { }

        private bool TurnToCoords(double X, double Y)
        {
            int myAngle = host.angle(host.me, X, Y);
            return host.Turn(-(myAngle / 180.0 * Math.PI), true);
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Tomiris")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_2423_1")) return false;
                Thread.Sleep(500);
                host.MoveTo(21104.06, 8336.24, 378.12);
                Thread.Sleep(500);
                host.MoveTo(21106.08, 8321.13, 378.48);
                Thread.Sleep(500);
                host.MoveTo(21115.32, 8316.51, 378.81);
                Thread.Sleep(1500);
                TurnToCoords(21115.45, 8322.10);
                host.MoveForward(true);
                host.Jump(true);
                while (host.me.Z < 380.65)
                    Thread.Sleep(10);
                host.Jump(false);
                host.MoveForward(false);
                if (host.me.Z < 382.65)
                {
                    TurnToCoords(21115.45, 8322.10);
                    host.MoveForward(true);
                    host.Jump(true);
                    while (host.me.Z < 382.65)
                        Thread.Sleep(10);
                    host.Jump(false);
                    host.MoveForward(false);
                }
                if (host.me.Z < 384.60)
                {
                    TurnToCoords(21115.45, 8322.10);
                    host.MoveForward(true);
                    host.Jump(true);
                    while (host.me.Z < 384.60)
                        Thread.Sleep(10);
                    host.Jump(false);
                    host.MoveForward(false);
                }

                Thread.Sleep(1500);
                TurnToCoords(21117.11, 8322.40);
                host.MoveForward(true);
                host.Jump(true);
                while (host.me.Z < 386.31)
                    Thread.Sleep(10);
                host.Jump(false);
                host.MoveForward(false);
                host.MoveTo(21122.40, 8324.45, 386.41);
                Thread.Sleep(1000);
                host.MoveTo(21121.95, 8327.67, 386.57);
                host.MoveForward(true);
                host.Jump(true);
                Thread.Sleep(100);
                host.Jump(false);
                host.MoveForward(false);
                host.MoveTo(21121.44, 8334.84, 387.37);
                Thread.Sleep(1500);
                //maybe need Teleport here?
                host.UseDoodadSkill(14053, host.getNearestDoodad(6533), true);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Tomiris")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
