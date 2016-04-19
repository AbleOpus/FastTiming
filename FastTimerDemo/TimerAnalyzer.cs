using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FastTimerDemo
{
    /// <summary>
    /// Responsible for sequentially analyzing timers.
    /// </summary>
    class TimerAnalyzer : IDisposable
    {
        private readonly Stack<TimerBenchmarkerBase> benchmarkerStack = new Stack<TimerBenchmarkerBase>();

        /// <summary>
        /// Gets the benchmark parameters for any timer benchmark initiated in this instance.
        /// </summary>
        protected BenchmarkParams benchParams;

        /// <summary>
        /// Occurs when an individual timer has been benchmarked.
        /// </summary>
        public event EventHandler<TimerBenchReport> TimerBenchmarked = delegate { };

        /// <summary>
        /// Occurs when all of the timers in the sequence have been benchmarked.
        /// </summary>
        public event EventHandler AnalysisCompleted = delegate { };

        /// <summary>
        /// Start the benchmarking asynchronously.
        /// </summary>
        public void RunAsync(BenchmarkParams benchParams)
        {
            this.benchParams = benchParams;
            // Find and instantiate all benchmark types, then add them to the benchmarking sequence.
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(TimerBenchmarkerBase)));

            foreach (var type in types)
                benchmarkerStack.Push((TimerBenchmarkerBase)Activator.CreateInstance(type));

            RunBenchmarker(benchmarkerStack.Pop());
        }

        /// <summary>
        /// Run benchmarkers recursively until no benchmark is left in the benchmark stack/sequence.
        /// </summary>
        /// <param name="benchmarker">The benchmark to start with.</param>
        private void RunBenchmarker(TimerBenchmarkerBase benchmarker)
        {
            benchmarker.BenchmarkFinished += async (s, e) =>
            {
                TimerBenchmarked(this, e);
                benchmarker.Dispose();

                if (benchmarkerStack.Count > 0)
                {
                    await Task.Delay(benchParams.RestInterval);

                    if (benchmarkerStack.Count > 0)
                    {
                        RunBenchmarker(benchmarkerStack.Pop());
                    }
                }
                else
                {
                    AnalysisCompleted(this, EventArgs.Empty);
                }
            };
            benchmarker.Run(benchParams);
        }

        public void Dispose()
        {
            while (benchmarkerStack.Count > 0)
                benchmarkerStack.Pop().Dispose();
        }
    }
}
