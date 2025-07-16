namespace IntegrationTestsFluentSeq.Sequence;

public sealed class SequenceOnStateChangedTests
{
    [Fact]
    public async Task StateChange_ShouldNotTrigger_missing_Action()
    {
        var state = new DefaultSequenceStates();

        var x = 0;
        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Builder()
            .Build();

        sequence.IsInState(state.Initializing).ShouldBeTrue();

        await sequence.RunAsync().ConfigureAwait(true);
        await sequence.RunAsync().ConfigureAwait(true);

        x.ShouldBe(0);
    }

    [Fact]
    public async Task StateChange_ShouldTrigger_Action_twice()
    {
        var state = new DefaultSequenceStates();

        var x = 0;
        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .OnStateChanged(() => x++)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Builder()
            .Build();

        sequence.IsInState(state.Initializing).ShouldBeTrue();

        await sequence.RunAsync().ConfigureAwait(true);
        await sequence.RunAsync().ConfigureAwait(true);

        x.ShouldBe(2);
    }

    [Fact]
    public async Task StateChange_ShouldTrigger_Action_three_times()
    {
        var state = new DefaultSequenceStates();

        var x = 0;
        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .OnStateChanged(() => x++)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true).WhenInState(state.Initializing)
            .ConfigureState(state.Activated).TriggeredBy(() => true).WhenInState(state.Initialized)
            .Builder()
            .Build();

        sequence.IsInState(state.Initializing).ShouldBeTrue();

        await sequence.RunAsync().ConfigureAwait(true);
        await sequence.RunAsync().ConfigureAwait(true);

        x.ShouldBe(3);
    }
}