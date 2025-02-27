namespace IntegrationTestsFluentSeq.Sequence;

public class SwitchToAnotherStateTests
{
    [Fact]
    public void TriggeredSeq_ShouldSwitch_to_initialized()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.RegisteredStates.Count.ShouldBe(2);
        sequence.CurrentState.ShouldBe(state.Initializing);

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
    }

    [Fact]
    public void PreviousState_ShouldBe_Initializing_after_new_state_is_set()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.RegisteredStates.Count.ShouldBe(2);
        sequence.CurrentState.ShouldBe(state.Initializing);

        sequence.Run();

        sequence.PreviousState.ShouldBe(state.Initializing);
    }

    [Fact]
    public void TriggeredSeq_ShouldSwitch_to_first_triggered_state()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .ConfigureState(state.On).TriggeredBy(() => true)
            .ConfigureState(state.Off).TriggeredBy(() => true)
            .Build();

        sequence.RegisteredStates.Count.ShouldBe(4);
        sequence.CurrentState.ShouldBe(state.Initializing);

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
    }

    [Fact]
    public void TriggeredSeq_ShouldNotSwitch_when_incorrect_CurrentState()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On).TriggeredBy(() => true).WhenInState(state.Initialized)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initializing);
    }

    [Fact]
    public void TriggeredSeq_ShouldSwitch_when_correct_CurrentState()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On).TriggeredBy(() => true).WhenInState(state.Initialized)
            .Build();

        sequence.SetState(state.Initialized);
        sequence.Run();

        sequence.CurrentState.ShouldBe(state.On);
    }

    [Theory]
    [InlineData(1, "Initialized")]
    [InlineData(50, "On")]
    public async Task TriggeredSeq_ShouldSwitch_when_correct_CurrentState_with_dwellTime(int dwellTimeInMs, string expectedState)
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On)
                .TriggeredBy(() => true)
                .WhenInState(state.Initialized, TimeSpan.FromMilliseconds(50))
            .Build();

        sequence.SetState(state.Initialized);

        await Task.Delay(dwellTimeInMs);
        await sequence.RunAsync();

        sequence.CurrentState.ShouldBe(expectedState);
    }

    [Fact]
    public void TriggeredSeq_ShouldSwitch_when_correct_CurrentStates()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.Off)
            .ConfigureState(state.On).TriggeredBy(() => true).WhenInStates(state.Initialized, state.Off)
            .Build();

        sequence.SetState(state.Off);
        sequence.Run();

        sequence.CurrentState.ShouldBe(state.On);
    }
}