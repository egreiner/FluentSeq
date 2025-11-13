namespace IntegrationTestsFluentSeq.Sequence;

public sealed class CurrentStateDurationTests
{
    [Theory]
    [InlineData("Initializing")]
    [InlineData("Initialized")]
    [InlineData("Off")]
    [InlineData("On")]
    public async Task CurrentStateDuration_ShouldBe_correct(string startState)
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

        await Task.Delay(2);

        sequence.CurrentStateDuration().ShouldBeGreaterThan(TimeSpan.FromMilliseconds(0.5));
    }
}