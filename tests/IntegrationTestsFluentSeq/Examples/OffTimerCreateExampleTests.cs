namespace IntegrationTestsFluentSeq.Examples;

public sealed class OffTimerCreateExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOffTimerConfiguration(int dwellTimeInMs) =>
        new FluentSeq<TimerState>().Create(TimerState.Off)
            .ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput)
            .ConfigureState(TimerState.Pending)
                .TriggeredBy(() => !_onTimerInput)
                .WhenInState(TimerState.On)
            .ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput)
                .WhenInState(TimerState.Pending, () => TimeSpan.FromMilliseconds(dwellTimeInMs))
            .Builder();

    [Theory]
    [InlineData(true, 9, 0, TimerState.Off, TimerState.On)]
    [InlineData(true, 9, 0, TimerState.Pending, TimerState.On)]
    [InlineData(true, 9, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 1, 2, TimerState.Off, TimerState.On)]
    [InlineData(true, 1, 2, TimerState.Pending, TimerState.On)]
    [InlineData(true, 1, 2, TimerState.On, TimerState.On)]

    [InlineData(false, 9,  0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 9,  0, TimerState.Pending, TimerState.Pending)]
    [InlineData(false, 9,  0, TimerState.On, TimerState.Pending)]

    [InlineData(false, 1, 2, TimerState.Off, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.On, TimerState.Pending)]
    public async Task Example_Usage_OffTimerConfiguration_Run_async(bool timerInput, int dwellTimeInMs, int sleepTimeInMs, TimerState currentState, TimerState expectedState)
    {
        _sequence     = GetOffTimerConfiguration(dwellTimeInMs).Build();
        _onTimerInput = timerInput;

        _sequence.SetState(currentState);

        await Task.Delay(sleepTimeInMs);
        await _sequence.RunAsync();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}