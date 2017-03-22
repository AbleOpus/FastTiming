using System;
using System.ComponentModel;

namespace FastTiming
{
    /// <summary>
    /// Represents a timer that is to be used for counting down to 0. The countdown
    /// counts in terms of ticks so how fast the countdown executes is determined
    /// by both the tick rate and <see cref="CountDownFrom"/> value.
    /// </summary>
    public class FastCountDownTimer : FastEventTimer
    {
        /// <summary>
        /// Gets the active countdown.
        /// </summary>
        [Browsable(false)]
        public int CountDown { get; private set; }

        private int countDownFrom = 10;
        /// <summary>
        /// Gets or sets the number to countdown from.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Value must be greater than 0.</exception>
        [Category("Behavior"), Description("The number to countdown from."), DefaultValue(10)]
        public int CountDownFrom
        {
            get { return countDownFrom; }
            set
            {
                if (countDownFrom < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than 0.");
                }

                if (CountDown > CountDownFrom)
                    CountDown = countDownFrom;

                countDownFrom = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastCountDownTimer"/> class.
        /// </summary>
        public FastCountDownTimer()
        {
            CountDown = CountDownFrom;
        }

        /// <summary>
        /// Occurs when the countdown has finished.
        /// </summary>
        [Category("Behavior"), Description("Occurs when the countdown has finished.")]
        public event EventHandler CountDownFinished = delegate { };
        /// <summary>
        /// Raises the <see cref="CountDownFinished"/> event.
        /// </summary>
        protected virtual void OnCountDownFinished()
        {
            CountDownFinished(this, EventArgs.Empty);
        }

        /// <summary>
        /// Resets the countdown.
        /// </summary>
        public virtual void Reset()
        {
            CountDown = CountDownFrom;
        }

        /// <summary>
        /// Raises when the value of the <see cref="FastTimerBase.Enabled"/> property has changed.
        /// </summary>
        protected override void OnEnabledChanged()
        {
            base.OnEnabledChanged();

            if (Enabled)
                Reset();
        }

        /// <summary>
        /// Invokes the <see cref="FastActionTimer.Tick"/> <see cref="Action"/>.
        /// </summary>
        protected override void OnTick()
        {
            CountDown--;
            base.OnTick();

            if (CountDown <= 0)
            {
                Stop();
                OnCountDownFinished();
            }
        }
    }
}
