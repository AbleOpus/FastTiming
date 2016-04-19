using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using FastTiming;

namespace FastTimingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FastActionTimer timer = new FastActionTimer();
        private readonly Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick = Tick;
            timer.Interval = 50;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            timer.Dispose();
            base.OnClosing(e);
        }

        private void Tick()
        {
            LabelText.Content = $"{stopwatch.Elapsed.Minutes:00}:{stopwatch.Elapsed.Seconds:00}." + 
                $@"{stopwatch.Elapsed.Milliseconds / 10:00}";
        }

        private void CheckBoxEnabled_Checked(object sender, RoutedEventArgs e)
        {
            timer.Start();
            stopwatch.Start();
        }

        private void CheckBoxEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            stopwatch.Stop();
        }
    }
}
