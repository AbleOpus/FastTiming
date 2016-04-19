using System;
using System.ComponentModel;

namespace FastTiming
{
    /// <summary>
    /// Represents a timer that tracks ticks and has a tick limit. When the tick limit
    /// is reached, an event fires specifying that the limit has been reached.
    /// </summary>
    public class FastLimitTimer : FastEventTimer
    {
        /// <summary>
        /// Gets how many times the timer has ticked.
        /// </summary>
        [Browsable(false)]
        public int Ticks { get; private set; }

        private int timeLimit;
        /// <summary>
        /// Gets the time limit of the timer. The tick count that needs to be reached
        /// for the <see cref="TimeLimitReached"/> event to fire.
        /// </summary>
        [Category("Behavior"), Description("The time limit of the timer. The tick count that needs to be " + 
            "reached for the TimeLimitReachedevent to fire.")]
        public int TimeLimit
        {
            get { return timeLimit;}
            set
            {
                if (value < 0)
                    throw new ArgumentException(nameof(value), "Value must be greater than or equal to 0.");

                timeLimit = value;
            }
        }

        /// <summary>
        /// Occurs when the time limit has been reached.
        /// </summary>
        [Category("Behavior"), Description("Occurs when the time limit has been reached.")]
        public event EventHandler TimeLimitReached = delegate { };
        /// <summary>
        /// Raises the <see cref="TimeLimitReached"/> event.
        /// </summary>
        protected virtual void OnTimeLimitReached()
        {
            TimeLimitReached(this, EventArgs.Empty);
        }

        /// <summary>
        /// Implements a tick notification which runs on the UI thread.
        /// </summary>
        protected override void OnTick()
        {
            base.OnTick();
            Ticks++;

            if (Ticks >= timeLimit && timeLimit != 0)
            {
                Stop();
                Ticks = 0;
                OnTimeLimitReached();
            }
        }
    }
}
