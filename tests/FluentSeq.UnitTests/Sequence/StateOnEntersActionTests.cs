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
                .TriggeredBy(() => true)
                .OnEntry(() => x = 2)
            .Build();

        // x = 0;
        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(2);
    }
}