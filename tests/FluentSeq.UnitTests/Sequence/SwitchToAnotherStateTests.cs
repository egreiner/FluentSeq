namespace FluentSeq.UnitTests.Sequence;

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

        var actual = sequence.CurrentState;
        sequence.RegisteredStates.Count.ShouldBe(2);
        actual.ShouldBe(state.Initializing);

        sequence.Run();

        actual = sequence.CurrentState;
        actual.ShouldBe(state.Initialized);
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

        var actual = sequence.CurrentState;
        sequence.RegisteredStates.Count.ShouldBe(4);
        actual.ShouldBe(state.Initializing);

        sequence.Run();

        actual = sequence.CurrentState;
        actual.ShouldBe(state.Initialized);
    }
}