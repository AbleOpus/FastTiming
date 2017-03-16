using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using FastTiming.Annotations;

namespace FastTiming
{
    /// <summary>
    /// The base implementation of a high resolution timer.
    /// </summary>
    [DefaultProperty(nameof(Interval))]
    public abstract class FastTimerBase : Component, INotifyPropertyChanged
    {
        private SynchronizationContext syncContext = SynchronizationContext.Current;
        private bool running;

        /// <summary>
        /// Gets or sets whether the timer will tick immediately when <see cref="Start"/> is called.
        /// </summary>
        [DefaultValue(false), Category("Behavior"), Description("whether the timer will tick immediately when Start is called.")]
        public virtual bool ImmediateTick { get; set; }

        private bool enabled;
        /// <summary>
        /// Gets or sets whether the timer is enabled.
        /// </summary>
        [Category("Behavior"), DefaultValue(false), Description("Whether the timer is enabled.")]
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value != enabled)
                {
                    enabled = value;

                    OnEnabledChanged();
                    OnPropertyChanged();

                    if (value && !running)
                    {
                        if (syncContext == null)
                            syncContext = SynchronizationContext.Current;

                        if (syncContext == null)
                            throw new InvalidOperationException("Synchronization context could not be set.");

                        if (ImmediateTick)
                            OnTick();

                        running = true;
                        RunTimerLoopAsync();
                    }
                }
            }
        }

        private int interval = 1000;
        /// <summary>
        /// Gets the time to wait between ticks in milliseconds.
        /// </summary>
        [Category("Behavior"), DefaultValue(1000), Description("The time to wait between ticks in milliseconds.")]
        public virtual int Interval
        {
            get { return interval; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value cannot be negative.", nameof(value));

                if (value != interval)
                {
                    interval = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastTimerBase"/> class.
        /// </summary>
        protected FastTimerBase()
        {
        }

        protected FastTimerBase(IContainer container) : this()
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Add(this);
        }

        /// <summary>
        /// Raises when the value of the <see cref="Enabled"/> property has changed.
        /// </summary>
        protected virtual void OnEnabledChanged() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastTimerBase"/> class
        /// with the specified argument.
        /// </summary>
        /// <param name="interval">The time between ticks in milliseconds.</param>
        protected FastTimerBase(TimeSpan interval) : this()
        {
            Interval = (int)(interval.TotalMilliseconds + 0.5);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastTimerBase"/> class
        /// with the specified argument.
        /// </summary>
        /// <param name="interval">The time between ticks in milliseconds.</param>
        public FastTimerBase(int interval) : this()
        {
            Interval = interval;
        }

        /// <summary>
        /// Implements a tick notification which runs on the UI thread.
        /// </summary>
        protected abstract void OnTick();

        private void RunTimerLoopAsync()
        {
            Task.Run(() =>
            {
                while (enabled)
                {
                    Thread.Sleep(Interval);

                    if (enabled)
                        syncContext.Post(PostCallback, null);
                }

                running = false;
            });
        }

        private void PostCallback(object state)
        {
            OnTick();
        }

        /// <summary>
        /// Enables the timer.
        /// </summary>
        public void Start()
        {
            Enabled = true;
        }

        /// <summary>
        /// Starts the timer after the delay has elapsed.
        /// </summary>
        /// <param name="delay">The time, in milliseconds, to wait before starting.</param>
        public Task StartDelayed(int delay)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(delay);
                syncContext.Post(o => Start(), null);
            });
        }

        /// <summary>
        /// Starts the timer after the delay has elapsed.
        /// </summary>
        /// <param name="delay">The time span to wait before starting.</param>
        public Task StartDelayed(TimeSpan delay)
        {
            return StartDelayed((int)delay.TotalMilliseconds);
        }

        /// <summary>
        /// Disables the timer.
        /// </summary>
        public void Stop()
        {
            Enabled = false;
        }

        /// <summary>
        /// Releases all resources used by the <see cref="FastTimerBase"/>.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Stop();

            base.Dispose(disposing);
        }

        /// <summary>
        /// Occurs when the value of any property in the instance has changed.
        /// </summary>
        [Browsable(false)]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
