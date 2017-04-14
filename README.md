# FastTiming
## Introduction
Note: A “Fast timer” is a timer that derives from the FastTimerBase class.
FastTiming is a class library which provides a high-resolution timer base which can be consumed and used for high-res timer implementations. Fast timers have a higher resolution and more predictable tick intervals than the timers provided by the .net framework. Fast timers provide thread-safe tick notifications much like a WinForms timer. However, the WinForms timer, along with all of other out-of-the-box timers, have a tick resolution of around 64 ticks per seconds. They also fire quite lazily – not on the desired tick time.

Some default implementations are provided by this library, the most important being the Action and event-driven timers which are usually all that is needed. The Action-based timer uses the Action type to provide instantaneous tick notifications. The tick notifications will raise on the consumer thread or the thread created in the instance (depends on the value of the TickOnConsumerThread property). This timer is slightly more accurate than the event-driven timer. However, even the action timer should not be used to accurately keep track of time. To keep track of time accurately, use a stopwatch with a timer, using the timer tick notification to evaluate and display the time provided by the stopwatch. Or, for longer time-tracking, continuously check the DateTime.Now property in a tick handler.
## Basics
The tick interval of a fast timer can be set in the constructor unless, of course, the fast timer was added via the designer. Fast timers inherit from Component, allowing the timers to be added and configured through designers which support Components. TheFastActionTimer is almost always the best timer to use in the library. The only difference between this and the event-driven timer is that the sender is not provided to the handler. You can still subscribe to Actions much like events.


```csharp
timer.Tick += Tick;
timer.Tick += Tick2;

private void Tick()
{
  LabelText.Content = $"{stopwatch.Elapsed.Seconds:00}.{stopwatch.Elapsed.Milliseconds / 10:00}";
}

private void Tick2()
{
  Title = $"{stopwatch.Elapsed.Seconds:00}.{stopwatch.Elapsed.Milliseconds / 10:00}";
}
```
The Start(), Stop(), Interval, and Enabled members are all used the same as with the other timers in the framework, and are almost fully self-explanatory and self-documenting. However, the properties "Enabled" and "Interval" are data bindable.
The StartDelayed(int) and StartDelayed(Timespan) methods can be used to start the timer after the specified time has elapsed. The following will start the timer after three seconds:

```csharp
timer.StartDelayed(3000);
```
Or
```csharp
timer.StartDelayed(TimeSpan.FromSeconds(3));
```

## Implementing FastTimerBase
Only one method is abstract and requires implementation – Tick(). Use this to fire a tick notification or do more specific work (like track ticks). OnEnabledChanged can be overridden to run logic when the timer starts or stops. The Start and Stop methods are shortcuts which set the Enabled property, therefore Start and Stop calls will invoke the OnEnabledChanged method. The ImmediateTick property determines whether the timer should tick immediately when enabled. This should be set in the constructor of an implementation if the default value is not appropriate for standard use of the implementation.

## The Projects
There are currently three projects in the solution.
FastTiming: The CLR-compliant class library with XML documentation. Make sure the XML documentation is present where the FastTiming DLL is referenced.
FastTimingDemo: A WPF stopwatch application demonstrating the FastActionTimer. (Also, I wanted to see if my thread marshalling worked with WPF).
FastTimingTest: A WinForms application that graphically compares the timers in the .net framework to the FastTimers provided by this library.

![alt text](http://i.imgur.com/lFWDFbU.png "100 MS Test")

The tester runs each timer for one second, tracking the tick times. The ticks are displayed on a timeline as a lime coloured line. The blue lines are the desired tick intervals. Note, the fast timers clearly tick much closer to the desired tick times in the above test. The test can also run the timers with an interval of one millisecond to see how fast they can tick. The tick resolution of the fast timer is around 2 milliseconds, ticking about 530 times per second.

![alt text](http://i.imgur.com/ByxZ8RL.png "100 MS Test")

All UserControls added to this project will be added automatically to the TimerTesterForm at runtime. They will be presented in a tab, the tab's caption being the UserControl’s text property. All classes which derive TimerBenchmarkBase will be found and initialized with reflections to then be benchmarked. The DisplayName attribute is used to describe the timer and any significant configuration it has. This is used to identify the benchmark results when they appear in the main test form.

```csharp
/// <summary>
/// Benchmarks a <see cref="System.Windows.Forms.Timer"/>.
/// </summary>
[DisplayName("Forms.Timer")]
class WinFormsTimerBenchmarker : TimerBenchmarkerBase
{
  private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

  public override void Run(BenchmarkParams benchParams)
  {
    base.Run(benchParams);
    timer.Interval = benchParams.TickInterval;
    timer.Tick += delegate { CheckIn(); };
    timer.Start();
  }

  public override void Dispose()
  {
    timer.Dispose();
  }
}
```
