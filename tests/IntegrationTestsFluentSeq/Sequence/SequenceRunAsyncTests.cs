namespace IntegrationTestsFluentSeq.Sequence;

public sealed class SequenceRunAsyncTests
{
    [Fact]
    public async Task RunAsync_ShouldRun_as_expected()
    {
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.Initialized).TriggeredBy(() => true)
            .Builder()
            .Build();

        sequence.IsInState(state.Initializing).ShouldBeTrue();

        await sequence.RunAsync().ConfigureAwait(true);

        sequence.IsInState(state.Initialized).ShouldBeTrue();
    }
}