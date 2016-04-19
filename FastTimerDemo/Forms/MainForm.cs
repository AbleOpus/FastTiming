using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FastTimerDemo.Forms
{
    public partial class MainForm : Form
    {
        private readonly TimerAnalyzer analyzer = new TimerAnalyzer();
        private BenchmarkParams benchParams = new BenchmarkParams(100, 1000, 1000);

        /// <summary>
        /// Gets or sets the currently selected <see cref="TickStripDisplayMode"/>.
        /// </summary>
        public TickStripDisplayMode SelectedTickStripDisplayMode
        {
            get { return (TickStripDisplayMode) comboBoxStripMode.SelectedItem; }
            set { comboBoxStripMode.SelectedItem = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            foreach (var val in Enum.GetValues(typeof(TickStripDisplayMode)))
                comboBoxStripMode.Items.Add(val);

            comboBoxStripMode.SelectedItem = TickStripDisplayMode.Both;

            analyzer.TimerBenchmarked += AnalyzerOnTimerBenchmarked;
            analyzer.AnalysisCompleted += delegate
            {
                labelStatus.Text = "Idle";
                buttonRunTest.Enabled = true;
            };
        }

        private void AnalyzerOnTimerBenchmarked(object sender, TimerBenchReport report)
        {
            TickStrip strip = new TickStrip();
            strip.Dock = DockStyle.Top;
            strip.Report = report;
            strip.BenchParams = benchParams;
            strip.DisplayMode = SelectedTickStripDisplayMode;
            panel.Controls.Add(strip);

            Label label = new Label();
            label.Visible = !checkBoxOnlyStrips.Checked;
            label.Font = new Font("Segoe UI", 12f);
            label.AutoSize = true;
            label.Text = report.ToString();
            label.Dock = DockStyle.Top;
            panel.Controls.Add(label);
        }

        private void buttonRunTest_Click(object sender, EventArgs e)
        {
            ClearPanel();
            labelStatus.Text = "Running Tests...";
            buttonRunTest.Enabled = false;
            benchParams = new BenchmarkParams((int)numberBoxTickInterval.Value, 1000, 1000);
            analyzer.RunAsync(benchParams);
        }

        private void checkBoxOnlyStrips_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var label in panel.Controls.OfType<Label>())
                label.Visible = !checkBoxOnlyStrips.Checked;
        }

        private void ClearPanel()
        {
            foreach (Control control in panel.Controls)
                control.Dispose();

            panel.Controls.Clear();
        }

        private void comboBoxStripMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var strips in panel.Controls.OfType<TickStrip>())
            {
                strips.DisplayMode = SelectedTickStripDisplayMode;
            }
        }

        private void buttonOpenTimerTester_Click(object sender, EventArgs e)
        {
            TimerTesterForm form = new TimerTesterForm();
            form.Show();
        }
    }
}
