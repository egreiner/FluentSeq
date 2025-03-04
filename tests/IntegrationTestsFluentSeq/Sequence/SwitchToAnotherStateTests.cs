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
            .Builder()
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
            .Builder()
            .Build();

        sequence.RegisteredStates.Count.ShouldBe(2);
        sequence.CurrentState.ShouldBe(state.Initializing);

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
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
            .Builder()
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
    [InlineData(0, "Initialized")]
    [InlineData(40, "On")]
    public async Task TriggeredSeq_ShouldSwitch_when_correct_CurrentState_with_dwellTime(int dwellTimeInMs, string expectedState)
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized)
            .ConfigureState(state.On)
                .TriggeredBy(() => true)
                .WhenInState(state.Initialized, () => TimeSpan.FromMilliseconds(20))
            .Builder()
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

    [Fact]
    public async Task TriggeredByState_ShouldSwitch_from_State_to_State()
    {
        var state = new DefaultSequenceStates();

        Func<TimeSpan> dwellTime() => () => TimeSpan.FromMilliseconds(1);

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredByState(state.Initializing, dwellTime())
            .ConfigureState(state.Off).TriggeredByState(state.Initialized, dwellTime())
            .ConfigureState(state.On).TriggeredByState(state.Off, dwellTime())
            .Builder()
            .Build();

        sequence.CurrentState.ShouldBe(state.Initializing);

        await Task.Delay(2);
        await sequence.RunAsync();
        sequence.CurrentState.ShouldBe(state.Initialized);

        await Task.Delay(2);
        await sequence.RunAsync();
        sequence.CurrentState.ShouldBe(state.Off);

        await Task.Delay(2);
        await sequence.RunAsync();
        sequence.CurrentState.ShouldBe(state.On);
    }
}