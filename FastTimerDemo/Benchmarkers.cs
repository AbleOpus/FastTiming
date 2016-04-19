using System;
using System.ComponentModel;
using FastTiming;

namespace FastTimerDemo
{
    /// <summary>
    /// Benchmarks a <see cref="System.Windows.Forms.Timer"/>.
    /// </summary>
    [DisplayName("Forms.Timer")]
    class WinFormsTimerBenchmarker : TimerBenchmarkerBase
    {
        private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);

            timer.Interval = benchParams.TickInterval;
            timer.Tick += delegate { CheckIn(); };
            timer.Start();
        }

        public override void Dispose()
        {
            timer.Dispose();
        }
    }

    /// <summary>
    /// Benchmarks a <see cref="System.Threading.Timer"/>.
    /// </summary>
    [DisplayName("Threading.Timer")]
    class ThreadingTimerBenchmarker : TimerBenchmarkerBase
    {
        private System.Threading.Timer timer;

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);
            var syncContext = System.Threading.SynchronizationContext.Current;

            System.Threading.TimerCallback method = state =>
            {
                syncContext.Post(CheckInPost, null);
            };
            timer = new System.Threading.Timer(method, null, benchParams.TickInterval, benchParams.TickInterval);
            // Starts automatically.
        }

        public override void Dispose()
        {
            timer?.Dispose();
        }
    }

    /// <summary>
    /// Benchmarks a <see cref="System.Timers.Timer"/>.
    /// </summary>
    [DisplayName("Timers.Timer")]
    class TimersTimerBenchmarker : TimerBenchmarkerBase
    {
        private readonly System.Timers.Timer timer = new System.Timers.Timer();

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);
            timer.Interval = benchParams.TickInterval;
            var syncContext = System.Threading.SynchronizationContext.Current;
            timer.Elapsed += delegate { syncContext.Post(CheckInPost, null); };
            timer.Start();
        }

        public override void Dispose()
        {
            timer.Dispose();
        }
    }

    /// <summary>
    /// Benchmarks a <see cref="FastEventTimer"/>.
    /// </summary>
    [DisplayName("FastTiming.FastEventTimer")]
    class FastEventTimerBenchmarker : TimerBenchmarkerBase
    {
        private readonly FastEventTimer timerBase = new FastEventTimer();

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);
            timerBase.Interval = benchParams.TickInterval;
            timerBase.Tick += delegate { CheckIn(); };
            timerBase.Start();
        }

        public override void Dispose()
        {
            timerBase.Dispose();
        }
    }

    /// <summary>
    /// Benchmarks a <see cref="FastActionTimer"/>.
    /// </summary>
    [DisplayName("FastTiming.FastActionTimer")]
    class FastActionTimerBenchmarker : TimerBenchmarkerBase
    {
        private readonly FastActionTimer timer = new FastActionTimer();

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);
            timer.Interval = benchParams.TickInterval;
            timer.Tick += CheckIn;
            timer.Start();
        }

        public override void Dispose()
        {
            timer.Dispose();
        }
    }

    /// <summary>
    /// Benchmarks a <see cref="System.Windows.Threading.DispatcherTimer"/> with the
    /// priority set to "Send" (which is the highest).
    /// </summary>
    [DisplayName("Threading.DispatcherTimer (Prioritized)")]
    class PrioritizedDispatcherTimerBenchmarker : TimerBenchmarkerBase
    {
        private readonly System.Windows.Threading.DispatcherTimer timer =
            new System.Windows.Threading.DispatcherTimer(System.Windows.Threading.DispatcherPriority.Send);

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);
            timer.Interval = TimeSpan.FromMilliseconds(benchParams.TickInterval);
            timer.Tick += delegate { CheckIn(); };
            timer.Start();
        }

        public override void Dispose()
        {
            timer.Stop();
        }
    }

    /// <summary>
    /// Benchmarks a <see cref="System.Windows.Threading.DispatcherTimer"/> with the
    /// priority left as default.
    /// </summary>
    [DisplayName("Threading.DispatcherTimer (Default)")]
    class DefaultDispatcherTimerBenchmarker : TimerBenchmarkerBase
    {
        private readonly System.Windows.Threading.DispatcherTimer timer =
            new System.Windows.Threading.DispatcherTimer();

        public override void Run(BenchmarkParams benchParams)
        {
            base.Run(benchParams);
            timer.Interval = TimeSpan.FromMilliseconds(benchParams.TickInterval);
            timer.Tick += delegate { CheckIn(); };
            timer.Start();
        }

        public override void Dispose()
        {
            timer.Stop();
        }
    }
}
