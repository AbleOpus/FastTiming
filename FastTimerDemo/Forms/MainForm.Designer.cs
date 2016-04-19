namespace FastTimerDemo.Forms
{
    partial class MainForm
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
                analyzer.Dispose();
            }
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonRunTest = new System.Windows.Forms.Button();
            this.checkBoxOnlyStrips = new System.Windows.Forms.CheckBox();
            this.comboBoxStripMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonOpenTimerTester = new System.Windows.Forms.Button();
            this.numberBoxTickInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxTickInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labelStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 390);
            this.statusStrip.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(785, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(26, 17);
            this.labelStatus.Text = "Idle";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.ForeColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(12, 38);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(761, 314);
            this.panel.TabIndex = 6;
            // 
            // buttonRunTest
            // 
            this.buttonRunTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunTest.Location = new System.Drawing.Point(669, 358);
            this.buttonRunTest.Name = "buttonRunTest";
            this.buttonRunTest.Size = new System.Drawing.Size(104, 23);
            this.buttonRunTest.TabIndex = 7;
            this.buttonRunTest.Text = "Run Test";
            this.toolTip.SetToolTip(this.buttonRunTest, "Start running the timer benchmarks\r\n");
            this.buttonRunTest.UseVisualStyleBackColor = true;
            this.buttonRunTest.Click += new System.EventHandler(this.buttonRunTest_Click);
            // 
            // checkBoxOnlyStrips
            // 
            this.checkBoxOnlyStrips.AutoSize = true;
            this.checkBoxOnlyStrips.Location = new System.Drawing.Point(552, 13);
            this.checkBoxOnlyStrips.Name = "checkBoxOnlyStrips";
            this.checkBoxOnlyStrips.Size = new System.Drawing.Size(114, 17);
            this.checkBoxOnlyStrips.TabIndex = 8;
            this.checkBoxOnlyStrips.Text = "Show Strips Only";
            this.toolTip.SetToolTip(this.checkBoxOnlyStrips, "Whether to show the tick strips only (without the labels).\r\nThis makes it slightl" +
        "y easier to compare the ticks.");
            this.checkBoxOnlyStrips.UseVisualStyleBackColor = true;
            this.checkBoxOnlyStrips.CheckedChanged += new System.EventHandler(this.checkBoxOnlyStrips_CheckedChanged);
            // 
            // comboBoxStripMode
            // 
            this.comboBoxStripMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStripMode.FormattingEnabled = true;
            this.comboBoxStripMode.Location = new System.Drawing.Point(128, 11);
            this.comboBoxStripMode.Name = "comboBoxStripMode";
            this.comboBoxStripMode.Size = new System.Drawing.Size(182, 21);
            this.comboBoxStripMode.TabIndex = 9;
            this.toolTip.SetToolTip(this.comboBoxStripMode, "Selects the display mode for the tick strips.\r\nSpecifying what elements to show.");
            this.comboBoxStripMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxStripMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Strip Display Mode";
            // 
            // buttonOpenTimerTester
            // 
            this.buttonOpenTimerTester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenTimerTester.Location = new System.Drawing.Point(520, 358);
            this.buttonOpenTimerTester.Name = "buttonOpenTimerTester";
            this.buttonOpenTimerTester.Size = new System.Drawing.Size(143, 23);
            this.buttonOpenTimerTester.TabIndex = 12;
            this.buttonOpenTimerTester.Text = "Open Timer Tester";
            this.buttonOpenTimerTester.UseVisualStyleBackColor = true;
            this.buttonOpenTimerTester.Click += new System.EventHandler(this.buttonOpenTimerTester_Click);
            // 
            // numberBoxTickInterval
            // 
            this.numberBoxTickInterval.Location = new System.Drawing.Point(414, 10);
            this.numberBoxTickInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numberBoxTickInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBoxTickInterval.Name = "numberBoxTickInterval";
            this.numberBoxTickInterval.Size = new System.Drawing.Size(120, 22);
            this.numberBoxTickInterval.TabIndex = 13;
            this.numberBoxTickInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tick Interval (MS)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 412);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberBoxTickInterval);
            this.Controls.Add(this.buttonOpenTimerTester);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxStripMode);
            this.Controls.Add(this.checkBoxOnlyStrips);
            this.Controls.Add(this.buttonRunTest);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "MainForm";
            this.Text = "Fast Timer Demo";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxTickInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonRunTest;
        private System.Windows.Forms.CheckBox checkBoxOnlyStrips;
        private System.Windows.Forms.ComboBox comboBoxStripMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonOpenTimerTester;
        private System.Windows.Forms.NumericUpDown numberBoxTickInterval;
        private System.Windows.Forms.Label label2;
    }
}

