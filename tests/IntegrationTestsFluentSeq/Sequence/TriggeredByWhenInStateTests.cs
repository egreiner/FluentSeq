namespace IntegrationTestsFluentSeq.Sequence;

public class TriggeredByWhenInStateTests
{
    [Fact]
    public void TriggeredSeq_ShouldNotSwitch_when_incorrect_CurrentState()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On).TriggeredBy(() => true).WhenInState(state.Initialized)
            .Builder()
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initializing);
    }

    [Fact]
    public void TriggeredSeq_ShouldSwitch_when_correct_CurrentState()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On).TriggeredBy(() => true).WhenInState(state.Initialized)
            .Builder()
            .Build();

        sequence.SetState(state.Initialized);
        sequence.Run();

        sequence.CurrentState.ShouldBe(state.On);
    }

    [Theory]
    [InlineData(100, 0, "Initialized")]
    [InlineData(0.1, 2, "On")]
    public async Task TriggeredSeq_ShouldSwitch_when_correct_CurrentState_with_dwellTime(double dwellTimeInMs, int delayInMs, string expectedState)
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On)
                .TriggeredBy(() => true)
                .WhenInState(state.Initialized, () => TimeSpan.FromMilliseconds(dwellTimeInMs))
            .Builder()
            .Build();

        sequence.SetState(state.Initialized);

        await Task.Delay(delayInMs);
        await sequence.RunAsync();

        sequence.CurrentState.ShouldBe(expectedState);
    }

    [Fact]
    public void TriggeredSeq_ShouldSwitch_when_correct_CurrentStates()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.Off)
            .ConfigureState(state.On).TriggeredBy(() => true).WhenInStates(state.Initialized, state.Off)
            .Builder()
            .Build();

        sequence.SetState(state.Off);
        sequence.Run();

        sequence.CurrentState.ShouldBe(state.On);
    }
}