namespace IntegrationTestsFluentSeq.Sequence;

public sealed class TriggeredByMultipleTriggerTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 0)]
    public async Task First_TriggeredBy_ShouldTrigger_the_Action(int value, int expected)
    {
        var x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.On)
                .TriggeredBy(() => value == 1)
                .TriggeredBy(() => value == 3)
                .OnEntry(() => x = value * 2)
            .Builder()
            .Build();

        await sequence.RunAsync();

        x.ShouldBe(expected);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 4)]
    public async Task Second_TriggeredBy_ShouldTrigger_the_Action(int value, int expected)
    {
        var x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.On)
                .TriggeredBy(() => value == 4)
                .TriggeredBy(() => value == 2)
                .OnEntry(() => x = value * 2)
            .Builder()
            .Build();

        await sequence.RunAsync();

        x.ShouldBe(expected);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    public async Task Both_TriggeredBy_ShouldTrigger_the_Action(int value, int expected)
    {
        var x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing).TriggeredBy(() => false)
            .ConfigureState(state.On)
                .TriggeredBy(() => value == 1)
                .TriggeredBy(() => value == 2)
                .OnEntry(() => x = value * 2)
            .Builder()
            .Build();

        await sequence.RunAsync();

        x.ShouldBe(expected);
    }
}