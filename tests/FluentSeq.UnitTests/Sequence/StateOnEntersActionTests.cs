namespace FluentSeq.UnitTests.Sequence;

public class StateOnEntryActionTests
{
    [Fact]
    public void TriggeredSeq_ShouldRaise_OnEntryAction()
    {
        int x=0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
                .TriggeredBy(() => false)
                 .OnEntry(() => x = 1)
            .ConfigureState(state.Initialized)
                // TODO this is running only in this code order, if its vice versa, it will not work
                .OnEntry(() => x = 2)
                .TriggeredBy(() => true)
            .Build();

        // x = 0;
        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(2);
    }
}