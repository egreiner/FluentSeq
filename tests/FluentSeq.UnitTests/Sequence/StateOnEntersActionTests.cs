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

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(2);
    }

    [Fact]
    public void TriggeredSeq_ShouldRaise_OnlyLast_OnEntryAction()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .TriggeredBy(() => false)
            .OnEntry(() => x *= 2)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .OnEntry(() => x *= 3)
            .OnEntry(() => x *= 4)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(4);
    }
}