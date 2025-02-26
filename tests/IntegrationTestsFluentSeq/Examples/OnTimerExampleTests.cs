namespace IntegrationTestsFluentSeq.Examples;

using FluentSeq.Builder;

public class OnTimerExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOnTimerConfiguration() =>
        new FluentSeq<TimerState>().Create(TimerState.Off)
            .DisableValidationForStates(TimerState.On)
            .ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput)
            .ConfigureState(TimerState.Pending)
                .TriggeredBy(() => _onTimerInput).WhenInState(TimerState.Off)
            .ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput && (_sequence?.CurrentStateElapsed(TimeSpan.FromMilliseconds(50)) ?? false)).WhenInState(TimerState.Pending)
            .Builder();

    [Theory]
    [InlineData(false, 0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 0, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 0, TimerState.On, TimerState.Off)]
    [InlineData(true,  0, TimerState.Off, TimerState.Pending)]
    [InlineData(true,  1, TimerState.Pending, TimerState.Pending)]
    [InlineData(true,  51, TimerState.Pending, TimerState.On)]
    [InlineData(true,  0, TimerState.On, TimerState.On)]
    public async Task Example_Usage_OnTimerConfiguration_Run_async_bla(bool timerInput, int sleepTimeInMs, TimerState currentState, TimerState expectedState)
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