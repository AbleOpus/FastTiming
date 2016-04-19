namespace FastTimerDemo.Forms
{
    partial class CountDownTimerDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTick = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.timer = new FastTiming.FastCountDownTimer();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelTick
            // 
            this.labelTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTick.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTick.Location = new System.Drawing.Point(0, 0);
            this.labelTick.Name = "labelTick";
            this.labelTick.Size = new System.Drawing.Size(496, 145);
            this.labelTick.TabIndex = 1;
            this.labelTick.Text = "N/A";
            this.labelTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(337, 148);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Location = new System.Drawing.Point(418, 152);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxEnabled.TabIndex = 3;
            this.checkBoxEnabled.Text = "Enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // CountDownTimerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelTick);
            this.Name = "CountDownTimerDisplay";
            this.Size = new System.Drawing.Size(496, 177);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTick;
        private System.Windows.Forms.Button buttonReset;
        private FastTiming.FastCountDownTimer timer;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
    }
}
