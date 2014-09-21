using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;
using AutoExp.Modules;
using AutoExp.Forms;
namespace AutoExp
{
    public class Host : Core
    {

        internal List<Module> modules = new List<Module>();
        internal CommonModule commonModule { get; set; }
        internal FarmModule farmModule { get; set; }
        internal MovementModule movementModule { get; set; }
        internal QuestModule questModule { get; set; }
        internal Main mainForm { get; set; }
        private Thread formThread;     

        public bool UseItemAndWait(uint id)
        {
            if (UseItem(id, true))
            {
                while (me.isCasting)
                    Thread.Sleep(50);
                return true;
            }
            return false;
        }

        private void RegisterModule(Module module)
        {
            modules.Add(module);
            module.Start(this);
        }

        private void RunForm()
        {
            try
            {
                Application.Run(mainForm);
            }
            catch (Exception error)
            {
                Log(error.ToString());
            }
        }

        public void PluginStop()
        {
            try
            {
                foreach (var module in modules)
                    module.Stop();
            }
            catch (Exception error)
            {
                Log(error.ToString());
            }
            try
            {
                if (mainForm != null)
                {
                    mainForm.Invoke(new Action(() => mainForm.Close()));
                    mainForm.Invoke(new Action(() => mainForm.Dispose()));
                }
                if (formThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    formThread.Abort();
                    formThread.Join();
                }
            }
            catch (Exception error)
            {
                Log(error.ToString());
            }
        }

        public void PluginRun()
        {
            try
            {
                mainForm = new Main();
                commonModule = new CommonModule();
                movementModule = new MovementModule();
                questModule = new QuestModule();
                farmModule = new FarmModule();
                ClearLogs();
                ResumeMoveTo();
                RegisterModule(commonModule);
                RegisterModule(farmModule);
                RegisterModule(movementModule);
                RegisterModule(questModule);

                formThread = new Thread(RunForm);
                formThread.SetApartmentState(ApartmentState.STA);
                formThread.Start();
                while (true)
                    Thread.Sleep(100);
            }
            catch (Exception error) {
                Log(error.ToString());
            }

        }
    }
}
