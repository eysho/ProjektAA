using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoExp.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void SetQuestModuleText(string text)
        {
            if (questModuleLabel.InvokeRequired)
                questModuleLabel.Invoke(new Action(() => { questModuleLabel.Text = "Q: " + text; }));
            else
                questModuleLabel.Text = "Q: " + text;
        }

        public void SetMovementModuleText(string text)
        {
            if (movementModuleLabel.InvokeRequired)
                movementModuleLabel.Invoke(new Action(() => { movementModuleLabel.Text = "M: " + text; }));
            else
                movementModuleLabel.Text = "M: " + text;
        }

        public void SetFarmModuleText(string text)
        {
            if (farmModuleLabel.InvokeRequired)
                farmModuleLabel.Invoke(new Action(() => { farmModuleLabel.Text = "F: " + text; }));
            else
                farmModuleLabel.Text = "F: " + text;
        }
    }
}
