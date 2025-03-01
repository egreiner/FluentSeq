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
            .SetInitialState(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.IsInState(state.Pending).ShouldBeFalse();
    }

    [Fact]
    public void IsInStates_ShouldBeTrue()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.IsInStates(state.Initializing, state.Initialized).ShouldBeTrue();

        sequence.Run();

        sequence.IsInStates(state.Initializing, state.Initialized).ShouldBeTrue();
    }

    [Fact]
    public void IsInStates_ShouldBeFalse()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.IsInStates(state.On, state.Off).ShouldBeFalse();

        sequence.Run();

        sequence.IsInStates(state.Activated, state.Deactivated).ShouldBeFalse();
    }


    [Fact]
    public void IsInStates_ShouldBeFalse_when_no_states_are_specified()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.IsInStates().ShouldBeFalse();
    }
}