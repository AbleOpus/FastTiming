using System;
using System.ComponentModel;

namespace FastTiming
{
    /// <summary>
    /// Represents a high-resolution timer which provides tick notifications
    /// through an <see cref="Action"/>.
    /// </summary>
    public class FastActionTimer : FastTimerBase
    {
        /// <summary>
        /// Gets or sets the action to invoke when the timer ticks.
        /// </summary>
        [Browsable(false)]
        public Action Tick { get; set; }

        /// <summary>
        /// Invokes the <see cref="Tick"/> <see cref="Action"/>.
        /// </summary>
        protected override void OnTick()
        {
            Tick?.Invoke();
        }
    }
}
