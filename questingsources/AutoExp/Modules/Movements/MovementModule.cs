using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Modules
{
    internal class MovementModule : Module
    {
        private Gps gps;
        private bool _gpsMoveEnabled;
        private bool regenBetweenGpsMoves = true;
        private bool forceGpsMove = false;
        public bool gpsMoveEnabled 
        {
            get 
            {
                return _gpsMoveEnabled;
            }
            set 
            {
                _gpsMoveEnabled = value;
                if (value)
                    host.mainForm.SetMovementModuleText("GpsMove");
                else
                    host.mainForm.SetMovementModuleText("");
            }
        }

        public override void Start(Host host)
        {
            base.Start(host);
            gps = new Gps(host);
            host.Log("Loading gps from " + Application.StartupPath + "\\plugins\\questing\\path.db3");
            gps.LoadDataBase(Application.StartupPath + "\\plugins\\questing\\path.db3");
            gps.onGpsPreMove += gpsPreMove;
        }

        public override void Run(CancellationToken ct)
        {
            while (true)
            {
                
                try
                {
                    base.Run(ct);
                }
                catch { }
                Thread.Sleep(10);
            }
        }

        public void EnableForceGpsMove()
        {
            gps.onGpsPreMove -= gpsPreMove;
            host.movementModule.regenBetweenGpsMoves = false;
            forceGpsMove = true;
        }

        public void DisableForceGpsMove()
        {
            host.movementModule.regenBetweenGpsMoves = true;
            gps.onGpsPreMove += gpsPreMove;
            forceGpsMove = false;
        }

        public void SuspendGpsMove()
        {
            Console.WriteLine("SuspendGpsMove");
            gps.SuspendGpsMove();
        }

        public void ResumeGpsMove()
        {
            Console.WriteLine("ResumeGpsMove");
            gps.ResumeGpsMove();
        }

        public bool gpsMoveSuspended
        {
            get
            {
                return gps.gpsMoveSuspended;
            }
        }

        private void CheckBadBosses()
        {
            foreach (var m in host.getCreatures())
            {
                if (m.creatureId >= 6443 && m.creatureId <= 6447 && host.dist(m) < 60)
                {
                    host.Log("ALARM. FOUND RAID BOSS " + m.name + "[" + m.creatureId + "]");
                    host.Log("CANT CONTINUE GPSMOVE WHILE RAID BOSS ALIVE. WAITING.");
                    while (host.isExists(m))
                        Thread.Sleep(1000);
                }
            }
        }

        private void gpsPreMove(GpsPoint point)
        {
            CheckBadBosses();
            host.commonModule.CheckSealedEquips();
            while (host.farmModule.aggroMobsCount() > 0 && host.me.isAlive())
                Thread.Sleep(300);
            while (regenBetweenGpsMoves && host.farmModule.aggroMobsCount() == 0 && host.me.isAlive() && (host.me.hpp < 65 || host.me.mpp < 40))
                Thread.Sleep(100);
            host.farmModule.PickUpNearMe();
        }

        public bool GpsMove(string name, int moveRetry = 3)
        {
            if (!host.farmModule.readyToActions)
                return false;
            var oldState = host.farmModule.farmState;
            if (!forceGpsMove)
                host.farmModule.SetFarmAggros();
            gpsMoveEnabled = true;
            bool result = gps.GpsMove(name);
            gpsMoveEnabled = false;
            if (!forceGpsMove)
                host.farmModule.farmState = oldState;
            if (!result)
            {
                Console.WriteLine("GPS MOVE FAIL");
                Console.WriteLine(host.GetLastError());
                if (moveRetry > 0)
                {
                    moveRetry--;
                    return GpsMove(name, moveRetry);
                }
                else
                {
                    Console.WriteLine("MOVE RETRY = 0. WE STUCK. WE NEED UNSTUCK?");
                }
            }
            return result;
        }
    }
}
