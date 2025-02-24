namespace FluentSeq.UnitTests.Sequence;

public class StateOnExitActionTests
{
    [Fact]
    public void TriggeredSeq_ShouldRaise_OnExitAction()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .OnExit(() => x = 1)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(1);
    }

    [Fact]
    public void TriggeredSeq_ShouldRaise_OnExitAction_only_once()
    {
        int x = 0;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .OnExit(() => x += 1)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .Build();

        for (int i = 0; i < 3; i++)
        {
            sequence.Run();

            sequence.CurrentState.ShouldBe(state.Initialized);
            x.ShouldBe(1);
        }
    }

    [Fact]
    public void TriggeredSeq_ShouldRaise_all_OnExitActions()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .OnExit(() => x *= 3)
            .OnExit(() => x *= 4)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(12);
    }

    [Fact]
    public void OnExit_ShouldBe_called_in_the_specified_order1()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .OnExit(() => x += 1)
            .OnExit(() => x *= 4)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(8);
        x.ShouldNotBe(5);
    }

    [Fact]
    public void OnExit_ShouldBe_called_in_the_specified_order2()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            // switch action order
            .OnExit(() => x *= 4)
            .OnExit(() => x += 1)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(5);
        x.ShouldNotBe(8);
    }

    [Fact]
    public void OnExit_ShouldBe_called_before_OnEntry1()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            .OnExit(() => x -= 1)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .OnEntry(() => x *= 4)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(0);
        x.ShouldNotBe(3);
    }

    [Fact]
    public void OnExit_ShouldBe_called_before_OnEntry2()
    {
        var x = 1;
        var state = new DefaultSequenceStates();

        var sequence = new FluentSeq<string>().Create(state.Initializing)
            .ConfigureState(state.Initializing)
            // switch OnEntry/OnExit actions
            .OnExit(() => x *= 4)
            .ConfigureState(state.Initialized)
            .TriggeredBy(() => true)
            .OnEntry(() => x -= 1)
            .Build();

        sequence.Run();

        sequence.CurrentState.ShouldBe(state.Initialized);
        x.ShouldBe(3);
        x.ShouldNotBe(0);
    }
}