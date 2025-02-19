namespace FluentSeq.UnitTests.Sequence;

public class SwitchToAnotherStateTests
{
    [Fact(Skip = "Not implemented yet")]
    public void TriggeredSeq_ShouldSwitch_to_requested_state()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.SetState(state.Initialized);
        //sequence.Run();

        var actual = sequence.CurrentState;
        actual.ShouldBe(state.Initialized);
    }
}