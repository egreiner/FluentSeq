namespace IntegrationTestsFluentSeq.Examples;

public class OnTimerConfigureExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOnTimerConfiguration(int dwellTimeInMs)
    {
        return new FluentSeq<TimerState>().Configure(TimerState.Off, builder =>
        {
            builder.ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput);

            builder.ConfigureState(TimerState.Pending)
                .TriggeredBy(() => _onTimerInput)
                .WhenInState(TimerState.Off);

            builder.ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput)
                .WhenInState(TimerState.Pending, () => TimeSpan.FromMilliseconds(dwellTimeInMs));
        }).Builder();
    }

    [Theory]
    [InlineData(false, 9, 0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 9, 0, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 9, 0, TimerState.On, TimerState.Off)]

    [InlineData(false, 1, 2, TimerState.Off, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 1, 2, TimerState.On, TimerState.Off)]

    [InlineData(true, 9, 0, TimerState.Off, TimerState.Pending)]
    [InlineData(true, 9, 0, TimerState.Pending, TimerState.Pending)]
    [InlineData(true, 9, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 1, 2, TimerState.Off, TimerState.Pending)]
    [InlineData(true, 1, 2, TimerState.Pending, TimerState.On)]
    [InlineData(true, 1, 2, TimerState.On, TimerState.On)]
    public async Task Example_Usage_OnTimerConfiguration_Run_async(bool timerInput, int dwellTimeInMs, int sleepTimeInMs, TimerState currentState, TimerState expectedState)
    {
        _sequence     = GetOnTimerConfiguration(dwellTimeInMs).Build();
        _onTimerInput = timerInput;

        _sequence.SetState(currentState);

        await Task.Delay(sleepTimeInMs);
        await _sequence.RunAsync();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}