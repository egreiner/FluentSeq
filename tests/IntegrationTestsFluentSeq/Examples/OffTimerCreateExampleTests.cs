namespace IntegrationTestsFluentSeq.Examples;

using FluentSeq.Builder;

public class OffTimerCreateExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOffTimerConfiguration() =>
        new FluentSeq<TimerState>().Create(TimerState.Off)
            .DisableValidationForStates(TimerState.On)
            .ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput)
            .ConfigureState(TimerState.Pending)
                .TriggeredBy(() => !_onTimerInput).WhenInState(TimerState.On)
            .ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput && (_sequence?.CurrentStateElapsed(TimeSpan.FromMilliseconds(50)) ?? false)).WhenInState(TimerState.Pending)
            .Builder();

    [Theory]
    [InlineData(true, 0, TimerState.Off, TimerState.On)]
    [InlineData(true, 0, TimerState.Pending, TimerState.On)]
    [InlineData(true, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 51, TimerState.Off, TimerState.On)]
    [InlineData(true, 51, TimerState.Pending, TimerState.On)]
    [InlineData(true, 51, TimerState.On, TimerState.On)]

    [InlineData(false, 0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 0, TimerState.Pending, TimerState.Pending)]
    [InlineData(false, 0, TimerState.On, TimerState.Pending)]

    [InlineData(false, 51, TimerState.Off, TimerState.Off)]
    [InlineData(false, 51, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 51, TimerState.On, TimerState.Pending)]
    public async Task Example_Usage_OnTimerConfiguration_Run_async_bla(bool timerInput, int sleepTimeInMs, TimerState currentState, TimerState expectedState)
    {
        _sequence     = GetOffTimerConfiguration().Build();
        _onTimerInput = timerInput;

        _sequence.SetState(currentState);

        await Task.Delay(sleepTimeInMs);
        await _sequence.RunAsync();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}