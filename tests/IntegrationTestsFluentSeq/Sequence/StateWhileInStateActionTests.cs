namespace IntegrationTestsFluentSeq.Sequence;

public class StateWhileInStateActionTests
{
    [Fact]
    public void SequenceRun_ShouldRaise_WhileInStateAction_repeatedly()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .WhileInState(() => x += 1)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(3);
    }

    [Fact]
    public void SequenceRun_ShouldRaise_all_WhileInStateAction_repeatedly()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .WhileInState(() => x += 1)
                .WhileInState(() => x *= 2)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(14);
    }

    [Fact]
    public void WhileInState_ShouldBe_called_in_the_specified_order1()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .WhileInState(() => x += 1)
                .WhileInState(() => x *= 2)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(22);
        x.ShouldNotBe(15);
    }


    [Fact]
    public void WhileInState_ShouldBe_called_in_the_specified_order2()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .WhileInState(() => x *= 2)
                .WhileInState(() => x += 1)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(15);
        x.ShouldNotBe(22);
    }

    [Fact]
    public void WhileInStateAction_ShouldBeCalled_after_OnExitAction_repeatedly()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .OnExit(() => x += 1)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .WhileInState(() => x *= 2)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(8);
    }

    [Fact]
    public void WhileInStateAction_ShouldBeCalled_after_OnEntryAction_repeatedly()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .OnEntry(() => x += 1)
                .WhileInState(() => x *= 2)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(8);
    }


    [Fact]
    public void Definition_order_ShouldBe_irrelevant()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .ConfigureState(state.Initialized)
                .TriggeredBy(() => true)
                .WhileInState(() => x *= 2)
                .OnEntry(() => x += 2)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();
            sequence.CurrentState.ShouldBe(state.Initialized);
        }

        x.ShouldBe(16);
    }
}