using System;
using System.ComponentModel;

namespace FastTiming
{
    /// <summary>
    /// Represents a high-resolution timer that provides tick notifications with an event.
    /// </summary>
    [DefaultEvent(nameof(Tick))]
    public class FastEventTimer : FastTimerBase
    {
        /// <summary>
        /// Occurs when the timer's interval has elapsed.
        /// </summary>
        [Category("Behavior"), Description("Occurs when the timer's interval has elapsed.")]
        public event EventHandler Tick = delegate { };

        /// <summary>
        /// Raises the <see cref="Tick"/> event.
        /// </summary>
        protected override void OnTick()
        {
            Tick(this, EventArgs.Empty);
        }
    }
}
