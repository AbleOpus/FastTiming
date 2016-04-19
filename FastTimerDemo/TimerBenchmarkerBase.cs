using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace FastTimerDemo
{
    /// <summary>
    /// Provides a base implementation for timer benchmarkers.
    /// </summary>
    abstract class TimerBenchmarkerBase : IDisposable
    {
        protected readonly List<long> Ticks = new List<long>();
        protected readonly Stopwatch Stopwatch = new Stopwatch();
        private readonly string displayName;

        /// <summary>
        /// Gets or sets the time, in milliseconds, in which the benchmark should run.
        /// </summary>
        protected int RunTime;

        /// <summary>
        /// Gets whether the benchmark is currently running.
        /// </summary>
        protected bool Running { get; private set; }

        /// <summary>
        /// Occurs when the benchmarking process has completed.
        /// </summary>
        public event EventHandler<TimerBenchReport> BenchmarkFinished = delegate { };

        protected TimerBenchmarkerBase()
        {
            var attributes = GetType().GetCustomAttributes<DisplayNameAttribute>();

            if (attributes != null && attributes.Count() > 0)
            {
                displayName = attributes.First().DisplayName;
            }
            else
            {
                throw new InvalidOperationException("No DisplayNameAttribute name has been set for this type.");
            }
        }

        /// <summary>
        /// Starts benchmarking the timer.
        /// </summary>
        /// <param name="benchParams">The parameters of the benchmark.</param>
        public virtual void Run(BenchmarkParams benchParams)
        {
            if (Running)
                throw new InvalidOperationException("Cannot run two benchmarks simultaneously.");

            RunTime = benchParams.RunTime;
            Running = true;
            Stopwatch.Restart();
            Ticks.Clear();
        }

        protected void Stop()
        {
            Stopwatch.Stop();
            Ticks.RemoveAll(t => t > RunTime);
            var report = new TimerBenchReport(Ticks.ToArray(), 1000f / Ticks.Count, displayName);
            BenchmarkFinished(this, report);
            Running = false;
        }

        /// <summary>
        /// Call this every time the timer ticks.
        /// </summary>
        protected void CheckIn()
        {
            Ticks.Add(Stopwatch.ElapsedMilliseconds);

            if (Stopwatch.ElapsedMilliseconds >= RunTime)
            {
                Dispose();
                Stop();
            }
        }

        /// <summary>
        /// Provides a callback for a <see cref="SynchronizationContext"/> post call.
        /// This is for timer tick notifications that are not thread-safe.
        /// </summary>
        /// <param name="state">Does not have a purpose here.</param>
        protected void CheckInPost(object state)
        {
            CheckIn();
        }

        public abstract void Dispose();
    }
}
