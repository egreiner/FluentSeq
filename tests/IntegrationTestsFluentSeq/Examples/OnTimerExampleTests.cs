namespace IntegrationTestsFluentSeq.Examples;

using FluentSeq.Builder;

public class OnTimerExampleTests
{
    private readonly DefaultSequenceStates _state = new();

    private ISequence<string>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<string> GetOnTimerConfiguration()
    {
        // return FluentSeq<string>.Create(_state.Off)
        //     .AddForceState(_state.Off, () => !_onTimerInput)
        //     .AddTransition(_state.Off, _state.Pending, () => _onTimerInput, () => _sequence?.Stopwatch.Restart())
        //     .AddTransition(_state.Pending, _state.On, () => _onTimerInput && _sequence?.Stopwatch.ElapsedMilliseconds > 50)
        //     .SetInitialState(_state.Off)
        //     .DisableValidationForStates(_state.On);

        return new FluentSeq<string>().Create(_state.Off)
            .DisableValidationForStates(_state.On)
            .ConfigureState(_state.Off)
                .TriggeredBy(() => !_onTimerInput)
            .ConfigureState(_state.Pending)
                .TriggeredBy(() => _onTimerInput).WhenInState(_state.Off)
            .ConfigureState(_state.On)
                .TriggeredBy(() => _onTimerInput).WhenInState(_state.Pending)
            .Builder();
    }

    [Theory]
    [InlineData(false, "Off")]
    [InlineData(true, "Pending")]
    public void Example_Usage_OnTimerConfiguration_Run_sync(bool timerInput, string expectedState)
    {
        _sequence = GetOnTimerConfiguration().Build();
        _onTimerInput = timerInput;

        _sequence.Run();

        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }

    // TODO: set start-state to exactly enable all specific state transition tests
    [Theory(Skip="Missing duration of the current state")]
    [InlineData(false, 0, "Off")]
    [InlineData(true, 0, "Pending")]
    [InlineData(true, 5, "Pending")]
    [InlineData(true, 51, "On")]
    public async Task Example_Usage_OnTimerConfiguration_Run_async(bool timerInput, int sleepTimeInMs, string expectedState)
    {
        _sequence = GetOnTimerConfiguration().Build();
        _onTimerInput = timerInput;


        await _sequence.RunAsync();

        await Task.Delay(sleepTimeInMs);

        await _sequence.RunAsync();


        var actual = _sequence.CurrentState;
        actual.ShouldBe(expectedState);
    }
}