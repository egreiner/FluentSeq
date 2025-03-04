namespace UnitTestsFluentSeq.Builder;

using FluentSeq.Builder;

public sealed class TriggerBuilderForEnumStatesTests
{
    [Fact]
    public void StateBuilder_TriggeredBy_ShouldReturn_TriggerBuilder()
    {
        var actual = new FluentSeq<TestState>().Create(TestState.Init)
            .ConfigureState(TestState.State1)
            .TriggeredBy(() => true);

        actual.ShouldBeOfType<TriggerBuilder<TestState>>();
    }

    [Fact]
    public void WhenInState_ShouldCreate_one_element()
    {
        var trigger = new FluentSeq<TestState>().Create(TestState.Init)
                .ConfigureState(TestState.State1)
                .TriggeredBy(() => true)
                .WhenInState(TestState.Bla);

        var actual = trigger.Trigger.WhenInStates;

        actual.ShouldHaveSingleItem();
    }

    [Fact]
    public void WhenInStates_ShouldCreate_four_elements()
    {
        var trigger = new FluentSeq<TestState>().Create(TestState.Init)
                .ConfigureState(TestState.State1)
                .TriggeredBy(() => true)
                .WhenInStates(TestState.Bla, TestState.Blub, TestState.Fizz, TestState.Buzz);

        var actual = trigger.Trigger.WhenInStates;

        actual.Count.ShouldBe(4);
    }


    [Fact]
    public void OnEntry_ShouldCreate_item_on_State_EntryActions()
    {
        var stateBuilder = new FluentSeq<TestState>().Create(TestState.Init)
            .ConfigureState(TestState.State1);

        var x = 0;
        stateBuilder.TriggeredBy(() => true)
                    .OnEntry(() => x = 2);

        var actual = stateBuilder.State.EntryActions;

        actual.ShouldHaveSingleItem();
        x.ShouldBe(0);
    }

    [Fact]
    public void OnExit_ShouldCreate_item_on_State_ExitActions()
    {
        var stateBuilder = new FluentSeq<TestState>().Create(TestState.Init)
            .ConfigureState(TestState.State1);

        var x = 0;
        stateBuilder.TriggeredBy(() => true)
                    .OnExit(() => x = 2);

        var actual = stateBuilder.State.ExitActions;

        actual.ShouldHaveSingleItem();
        x.ShouldBe(0);
    }

    [Fact]
    public void WhileInState_ShouldCreate_item_on_State_WhileInStateActions()
    {
        var stateBuilder = new FluentSeq<TestState>().Create(TestState.Init)
            .ConfigureState(TestState.State1);

        var x = 0;
        stateBuilder.TriggeredBy(() => true)
                    .WhileInState(() => x = 2);

        var actual = stateBuilder.State.WhileInStateActions;

        actual.ShouldHaveSingleItem();
        x.ShouldBe(0);
    }
}