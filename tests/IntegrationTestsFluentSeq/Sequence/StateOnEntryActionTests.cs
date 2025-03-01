namespace IntegrationTestsFluentSeq.Sequence;

public class StateOnEntryActionTests
{
    [Fact]
    public void TriggeredSeq_ShouldRaise_OnEntryAction()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .OnEntry(() => x = 2)
            .Builder()
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(2);
    }

    [Fact]
    public void TriggeredSeq_ShouldRaise_OnEntryAction_only_once()
    {
        int x=0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .OnEntry(() => x += 2)
            .Builder()
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();

            sequence.CurrentState.ShouldBe(state.Initialized);
            x.ShouldBe(2);
        }
    }

    [Fact]
    public void TriggeredSeq_ShouldRaise_all_OnEntryActions()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .OnEntry(() => x *= 3)
                .OnEntry(() => x *= 4)
            .Builder()
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(12);
    }

    [Fact]
    public void OnEntry_ShouldBe_called_in_the_specified_order1()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .OnEntry(() => x += 3)
                .OnEntry(() => x *= 4)
            .Builder()
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(16);
        x.ShouldNotBe(7);
    }

    [Fact]
    public void OnEntry_ShouldBe_called_in_the_specified_order2()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .DisableValidation()
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                // switch action order
                .OnEntry(() => x *= 4)
                .OnEntry(() => x += 3)
            .Builder()
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(7);
        x.ShouldNotBe(16);
    }
}