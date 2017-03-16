using System;
using System.Windows.Forms;
using FastTiming;

namespace FastTimerDemo.Forms
{
    public partial class MiscTestDisplay : UserControl
    {
        private readonly FastActionTimer timer = new FastActionTimer();
        private int ticks;

        public MiscTestDisplay()
        {
            InitializeComponent();
            base.Text = "Misc Testing";
            timer.Tick = delegate { labelTicks.Text = (++ticks).ToString(); };
        }

        private async void buttonStartDelayed_Click(object sender, EventArgs e)
        {
            buttonStartDelayed.Enabled = false;
            await timer.StartDelayed(3000);
            listBox.Items.Add("Started");
            buttonStartDelayed.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            listBox.Items.Add("Stopped");
        }
    }
}
