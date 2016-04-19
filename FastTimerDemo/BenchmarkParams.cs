using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTimerDemo
{
    /// <summary>
    /// Represents parameters for benchmarking timers.
    /// </summary>
    struct BenchmarkParams
    {
        /// <summary>
        /// Gets whether the parameters are valid for benchmarking.
        /// </summary>
        public bool IsValid => TickInterval != 0 && RunTime != 0 && RestInterval != 0;

        /// <summary>
        /// Gets or sets the interval, in milliseconds, the timers should tick.
        /// </summary>
        public int TickInterval { get; }

        /// <summary>
        /// Gets or sets how long, in milliseconds, the timers should run.
        /// </summary>
        public int RunTime { get; }

        /// <summary>
        /// Gets or sets the interval, in milliseconds, between individual timer benchmarks.
        /// A rest time, for resources to free up.
        /// </summary>
        public int RestInterval { get;  }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenchmarkParams"/> with the specified
        /// arguments.
        /// </summary>
        /// <param name="tickInterval">The interval, in milliseconds, the timers should tick.</param>
        /// <param name="restInterval">The interval, in milliseconds, between individual timer benchmarks.
        /// A rest time, for resources to free up.</param>
        /// <param name="runTime">How long, in milliseconds, the timers should run.</param>
        public BenchmarkParams(int tickInterval, int restInterval, int runTime)
        {
            TickInterval = tickInterval;
            RestInterval = restInterval;
            RunTime = runTime;
        }
    }
}
