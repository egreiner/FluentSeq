namespace IntegrationTestsFluentSeq.Sequence;

public class SequenceIsInStateTests
{
    [Fact]
    public void IsInState_ShouldBeTrue()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.IsInState(state.Initializing).ShouldBeTrue();

        sequence.Run();

        sequence.IsInState(state.Initialized).ShouldBeTrue();
    }

    [Fact]
    public void IsInState_ShouldBeFalse()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.IsInState(state.Pending).ShouldBeFalse();
    }
}