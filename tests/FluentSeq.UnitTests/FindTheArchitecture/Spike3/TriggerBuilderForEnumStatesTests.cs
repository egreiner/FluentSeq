namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

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
}