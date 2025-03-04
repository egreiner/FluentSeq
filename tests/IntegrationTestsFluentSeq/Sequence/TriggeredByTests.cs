namespace IntegrationTestsFluentSeq.Sequence;

public class TriggeredByTests
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
}