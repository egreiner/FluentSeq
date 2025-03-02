namespace IntegrationTestsFluentSeq.Examples;

using FluentSeq.Builder;
using FluentSeq.Extensions;

public class OnTimerCreateExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOnTimerConfiguration() =>
        new FluentSeq<TimerState>().Create(TimerState.Off)
            .ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput)
            .ConfigureState(TimerState.Pending)
                .TriggeredBy(() => _onTimerInput)
                .WhenInState(TimerState.Off)
            .ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput)
                .WhenInState(TimerState.Pending, TimeSpan.FromMilliseconds(20))
            .Builder();

    [Theory]
    [InlineData(false, 0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 0, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 0, TimerState.On, TimerState.Off)]

    [InlineData(false, 40, TimerState.Off, TimerState.Off)]
    [InlineData(false, 40, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 40, TimerState.On, TimerState.Off)]

    [InlineData(true, 0, TimerState.Off, TimerState.Pending)]
    [InlineData(true, 0, TimerState.Pending, TimerState.Pending)]
    [InlineData(true, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 40, TimerState.Off, TimerState.Pending)]
    [InlineData(true, 40, TimerState.Pending, TimerState.On)]
    [InlineData(true, 40, TimerState.On, TimerState.On)]
    public async Task Example_Usage_OnTimerConfiguration_Run_async(bool timerInput, int sleepTimeInMs, TimerState currentState, TimerState expectedState)
    {
        _sequence     = GetOnTimerConfiguration().Build();
        _onTimerInput = timerInput;

        _sequence.SetState(currentState);

        await Task.Delay(sleepTimeInMs);
        await _sequence.RunAsync();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}