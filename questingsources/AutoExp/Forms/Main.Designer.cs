namespace AutoExp.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.farmModuleLabel = new System.Windows.Forms.Label();
            this.questModuleLabel = new System.Windows.Forms.Label();
            this.movementModuleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // farmModuleLabel
            // 
            this.farmModuleLabel.AutoSize = true;
            this.farmModuleLabel.Location = new System.Drawing.Point(29, 31);
            this.farmModuleLabel.Name = "farmModuleLabel";
            this.farmModuleLabel.Size = new System.Drawing.Size(33, 13);
            this.farmModuleLabel.TabIndex = 1;
            this.farmModuleLabel.Text = "Farm:";
            // 
            // questModuleLabel
            // 
            this.questModuleLabel.AutoSize = true;
            this.questModuleLabel.Location = new System.Drawing.Point(29, 54);
            this.questModuleLabel.Name = "questModuleLabel";
            this.questModuleLabel.Size = new System.Drawing.Size(38, 13);
            this.questModuleLabel.TabIndex = 3;
            this.questModuleLabel.Text = "Quest:";
            // 
            // movementModuleLabel
            // 
            this.movementModuleLabel.AutoSize = true;
            this.movementModuleLabel.Location = new System.Drawing.Point(29, 76);
            this.movementModuleLabel.Name = "movementModuleLabel";
            this.movementModuleLabel.Size = new System.Drawing.Size(60, 13);
            this.movementModuleLabel.TabIndex = 4;
            this.movementModuleLabel.Text = "Movement:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Flags:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 102);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.movementModuleLabel);
            this.Controls.Add(this.questModuleLabel);
            this.Controls.Add(this.farmModuleLabel);
            this.Name = "Main";
            this.Text = "AutoExp v0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label farmModuleLabel;
        private System.Windows.Forms.Label questModuleLabel;
        private System.Windows.Forms.Label movementModuleLabel;
        private System.Windows.Forms.Label label1;
    }
}