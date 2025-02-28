namespace IntegrationTestsFluentSeq.Examples;

using FluentSeq.Builder;
using FluentSeq.Extensions;

public class OffTimerConfigureExampleTests
{
    private ISequence<TimerState>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<TimerState> GetOffTimerConfiguration() =>
        new FluentSeq<TimerState>().Configure(TimerState.Off, builder =>
        {
            builder.DisableValidationTemporarily();

            builder.DisableValidationForStates(TimerState.On);

            builder.ConfigureState(TimerState.On)
                .TriggeredBy(() => _onTimerInput);

            builder.ConfigureState(TimerState.Pending)
                .TriggeredBy(() => !_onTimerInput)
                .WhenInState(TimerState.On);

            builder.ConfigureState(TimerState.Off)
                .TriggeredBy(() => !_onTimerInput)
                .WhenInState(TimerState.Pending, TimeSpan.FromMilliseconds(20));
        }).Builder();


    [Theory]
    [InlineData(true, 0, TimerState.Off, TimerState.On)]
    [InlineData(true, 0, TimerState.Pending, TimerState.On)]
    [InlineData(true, 0, TimerState.On, TimerState.On)]

    [InlineData(true, 40, TimerState.Off, TimerState.On)]
    [InlineData(true, 40, TimerState.Pending, TimerState.On)]
    [InlineData(true, 40, TimerState.On, TimerState.On)]

    [InlineData(false, 0, TimerState.Off, TimerState.Off)]
    [InlineData(false, 0, TimerState.Pending, TimerState.Pending)]
    [InlineData(false, 0, TimerState.On, TimerState.Pending)]

    [InlineData(false, 40, TimerState.Off, TimerState.Off)]
    [InlineData(false, 40, TimerState.Pending, TimerState.Off)]
    [InlineData(false, 40, TimerState.On, TimerState.Pending)]
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