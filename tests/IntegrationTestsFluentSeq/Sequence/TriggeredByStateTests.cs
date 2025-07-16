namespace IntegrationTestsFluentSeq.Sequence;

public sealed class TriggeredByStateTests
{
    [Theory]
    [InlineData("Initializing", "Initialized")]
    [InlineData("Initialized", "Off")]
    [InlineData("Off", "On")]
    public async Task TriggeredByState_ShouldSwitch_to_correct_State(string startState,string expectedState)
    {
        var state = new DefaultSequenceStates();

        Func<TimeSpan> dwellTime() => () => TimeSpan.FromMilliseconds(0.01);

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredByState(state.Initializing, dwellTime())
            .ConfigureState(state.Off).TriggeredByState(state.Initialized, dwellTime())
            .ConfigureState(state.On).TriggeredByState(state.Off, dwellTime())
            .Builder()
            .Build();

        sequence.SetState(startState);

        await Task.Delay(1);

        await sequence.RunAsync();
        sequence.CurrentState.ShouldBe(expectedState);
    }
}