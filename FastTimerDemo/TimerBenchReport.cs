using System;
using System.Linq;

namespace FastTimerDemo
{
    /// <summary>
    /// Represents timer benchmark results.
    /// </summary>
    class TimerBenchReport
    {
        /// <summary>
        /// Gets the name of the test. This should describe what timer is being tested
        /// and any distinguishing parameters the timer is using.
        /// </summary>
        public string TestName { get; }

        /// <summary>
        /// Gets the times during the run time, in milliseconds, in which the timer has ticked.
        /// </summary>
        public long[] TickTimes { get; }

        /// <summary>
        /// Gets the tick resolution.
        /// </summary>
        public float TickResolution { get; }

        /// <summary>
        /// Gets how many times the timer ticked within the run time of the benchmark.
        /// </summary>
        public int TicksCount => TickTimes.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerBenchReport"/> class
        /// with the specified arguments.
        /// </summary>
        /// <param name="tickTimes">The times during the run time, in milliseconds, in which the timer has ticked.</param>
        /// <param name="tickResolution">The tick resolution.</param>
        /// <param name="testName">The name of the test. This should describe what timer is being tested
        /// and any distinguishing parameters the timer is using.</param>
        public TimerBenchReport(long[] tickTimes, float tickResolution, string testName)
        {
            TickTimes = tickTimes;
            TickResolution = tickResolution;
            TestName = testName;
        }

        public override string ToString()
        {
            return $"Test Name: {TestName}, Resolution: {Math.Round(TickResolution, 2)}," 
                + $" Ticks Per Second: {TicksCount}";
        }
    }
}
