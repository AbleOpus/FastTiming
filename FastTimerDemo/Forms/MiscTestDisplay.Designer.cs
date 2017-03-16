namespace FastTimerDemo.Forms
{
    partial class MiscTestDisplay
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
            if (disposing)
            {
                timer.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonStartDelayed = new System.Windows.Forms.Button();
            this.labelTicks = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(3, 3);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(481, 158);
            this.listBox.TabIndex = 0;
            // 
            // buttonStartDelayed
            // 
            this.buttonStartDelayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartDelayed.Location = new System.Drawing.Point(296, 163);
            this.buttonStartDelayed.Name = "buttonStartDelayed";
            this.buttonStartDelayed.Size = new System.Drawing.Size(188, 23);
            this.buttonStartDelayed.TabIndex = 1;
            this.buttonStartDelayed.Text = "Start Delayed (3 sec)";
            this.buttonStartDelayed.UseVisualStyleBackColor = true;
            this.buttonStartDelayed.Click += new System.EventHandler(this.buttonStartDelayed_Click);
            // 
            // labelTicks
            // 
            this.labelTicks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTicks.AutoSize = true;
            this.labelTicks.Location = new System.Drawing.Point(9, 168);
            this.labelTicks.Name = "labelTicks";
            this.labelTicks.Size = new System.Drawing.Size(45, 13);
            this.labelTicks.TabIndex = 2;
            this.labelTicks.Text = "Ticks: 0";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(200, 163);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(90, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // MiscTestDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelTicks);
            this.Controls.Add(this.buttonStartDelayed);
            this.Controls.Add(this.listBox);
            this.Name = "MiscTestDisplay";
            this.Size = new System.Drawing.Size(487, 189);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonStartDelayed;
        private System.Windows.Forms.Label labelTicks;
        private System.Windows.Forms.Button buttonStop;
    }
}
