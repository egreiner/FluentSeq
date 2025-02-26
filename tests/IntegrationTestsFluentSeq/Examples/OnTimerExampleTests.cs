namespace IntegrationTestsFluentSeq.Examples;

using FluentSeq.Builder;

public class OnTimerExampleTests
{
    private readonly DefaultSequenceStates _state = new();

    private ISequence<string>? _sequence;
    private bool _onTimerInput;


    private ISequenceBuilder<string> GetOnTimerConfiguration() =>
        new FluentSeq<string>().Create(_state.Off)
            .DisableValidationForStates(_state.On)
            .ConfigureState(_state.Off)
                .TriggeredBy(() => !_onTimerInput)
            .ConfigureState(_state.Pending)
                .TriggeredBy(() => _onTimerInput).WhenInState(_state.Off)
            .ConfigureState(_state.On)
                .TriggeredBy(() => _onTimerInput && (_sequence?.CurrentStateElapsed(TimeSpan.FromMilliseconds(50)) ?? false)).WhenInState(_state.Pending)
            .Builder();

    [Theory]
    [InlineData(false, 0, "Off", "Off")]
    [InlineData(false, 0, "Pending", "Off")]
    [InlineData(false, 0, "On", "Off")]
    [InlineData(true, 0, "Off", "Pending")]
    [InlineData(true, 1, "Pending", "Pending")]
    [InlineData(true, 51, "Pending", "On")]
    [InlineData(true, 0, "On", "On")]
    public async Task Example_Usage_OnTimerConfiguration_Run_async_bla(bool timerInput, int sleepTimeInMs, string currentState, string expectedState)
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