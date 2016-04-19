using System;
using System.Windows.Forms;

namespace FastTimerDemo.Forms
{
    public partial class CountDownTimerDisplay : UserControl
    {
        public CountDownTimerDisplay()
        {
            InitializeComponent();
            base.Text = "CountDownTimer Demo";
            var binding = new Binding(nameof(checkBoxEnabled.Checked), timer, nameof(timer.Enabled), false, DataSourceUpdateMode.OnPropertyChanged);
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            checkBoxEnabled.DataBindings.Add(binding);
            timer.Tick += (sender, args) => labelTick.Text = timer.CountDown.ToString();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            timer.Reset();
        }
    }
}
