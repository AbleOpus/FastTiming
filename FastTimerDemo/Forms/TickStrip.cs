using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FastTimerDemo.Forms
{
    sealed class TickStrip : Control
    {
        private readonly Pen expectedTicksPen = new Pen(Color.DodgerBlue, 1);
        /// <summary>
        /// Gets or sets the color of the expected timer tick indicators.
        /// </summary>
        [Description("The color of the expected timer tick indicators."), Category("Appearance"), 
            DefaultValue(typeof(Color), "DodgerBlue")]
        public Color ExpectedTicksColor
        {
            get { return expectedTicksPen.Color; }
            set { expectedTicksPen.Color = value; }
        }

        private readonly Pen actualTicksPen = new Pen(Color.GreenYellow, 1);
        /// <summary>
        /// Gets or sets the color of the timer tick indicators.
        /// </summary>
        [Description("The color of the timer tick indicators."), Category("Appearance"), 
            DefaultValue(typeof(Color), "GreenYellow")]
        public Color ActualTicksColor
        {
            get { return actualTicksPen.Color; }
            set { actualTicksPen.Color = value; }
        }

        private TickStripDisplayMode displayMode = TickStripDisplayMode.Both;
        /// <summary>
        /// Gets or sets the display mode of this control.
        /// </summary>
        [Description("The display mode of this control."), Category("Appearance"),
            DefaultValue(TickStripDisplayMode.Both)]
        public TickStripDisplayMode DisplayMode
        {
            get { return displayMode; }
            set
            {
                displayMode = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public BenchmarkParams BenchParams { get; set; }

        [Browsable(false)]
        public TimerBenchReport Report { get; set; }

        public TickStrip()
        {
            ResizeRedraw = true;
            DoubleBuffered = true;
            BackColor = Color.Black;
        }

        protected override Size DefaultSize => new Size(200, 30);

        private void DrawExpectedTicks(Graphics graphics)
        {
            float section = Width * (float)BenchParams.TickInterval / BenchParams.RunTime;
            float pos = section;

            while (pos < Width)
            {
                graphics.DrawLine(expectedTicksPen, pos, 0, pos, Height);
                pos += section;
            }
        }

        private void DrawTimerTicks(Graphics graphics)
        {
            foreach (var tick in Report.TickTimes)
            {
                float xPos = Width * tick / (float)BenchParams.RunTime;
                float x = xPos > Width - 1 ? Width - 1 : xPos;
                graphics.DrawLine(actualTicksPen, x, 0, x, Height);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Report != null && BenchParams.IsValid)
            {
                // Draw desired tick positions.
                switch (displayMode)
                {
                    case TickStripDisplayMode.Both:
                        DrawExpectedTicks(e.Graphics);
                        DrawTimerTicks(e.Graphics);
                        break;

                    case TickStripDisplayMode.ExpectedTicks:
                        DrawExpectedTicks(e.Graphics);
                        break;

                    case TickStripDisplayMode.TimerTicks:
                        DrawTimerTicks(e.Graphics);
                        break;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                expectedTicksPen.Dispose();
                actualTicksPen.Dispose();
            }

            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Specifies what tick information is displayed on a <see cref="TickStrip"/> control.
    /// </summary>
    public enum TickStripDisplayMode
    {
        /// <summary>
        /// Only the expected ticks are displayed.
        /// </summary>
        ExpectedTicks,
        /// <summary>
        /// Only the timer ticks are displayed.
        /// </summary>
        TimerTicks,
        /// <summary>
        /// Both the expected and timer ticks are displayed.
        /// </summary>
        Both
    }
}
