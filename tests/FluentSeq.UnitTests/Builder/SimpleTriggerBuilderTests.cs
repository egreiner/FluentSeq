namespace FluentSeq.UnitTests.Builder;

using FluentSeq.Builder;

public sealed class SimpleTriggerBuilderTests
{
    [Fact]
    public void StateBuilder_TriggeredBy_ShouldReturn_TriggerBuilder()
    {
        var actual = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true);

        actual.ShouldBeOfType<TriggerBuilder<string>>();
    }

    [Fact]
    public void TriggerBuilder_ShouldContain_Trigger()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true);

        var actual = builder.Trigger;

        actual.ShouldNotBeNull();
    }

    [Fact]
    public void TriggerBuilder_ShouldAdd_Trigger_to_state()
    {
        var stateBuilder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1");

        var triggerBuilder = stateBuilder.TriggeredBy(() => true);

        var trigger = triggerBuilder.Trigger;

        var actual = stateBuilder.State.Trigger;
        actual.ShouldContain(trigger);
    }

    [Fact]
    public void Trigger_WhenInStates_ShouldBeEmpty_per_default()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true);

        var actual = builder.Trigger.WhenInStates;

        actual.ShouldBeEmpty();
    }

    [Fact]
    public void WhenInState_ShouldCreate_one_element()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla");

        var actual = builder.Trigger.WhenInStates;

        actual.ShouldHaveSingleItem();
    }

    [Fact]
    public void WhenInState_ShouldCreate_two_elements()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla")
            .WhenInState("Blub");

        var actual = builder.Trigger.WhenInStates;

        actual.Count.ShouldBe(2);
    }

    [Fact]
    public void WhenInStates_ShouldCreate_one_element()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInStates("Bla");

        var actual = builder.Trigger.WhenInStates;

        actual.ShouldHaveSingleItem();
    }

    [Fact]
    public void WhenInStates_ShouldCreate_four_elements()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInStates("Bla", "Blub", "Fizz", "Buzz");

        var actual = builder.Trigger.WhenInStates;

        actual.Count.ShouldBe(4);
    }


    [Fact]
    public void Combined_WhenInState_and_WhenInStates_ShouldCreate_four_elements()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla")
            .WhenInStates("Blub", "Fizz", "Buzz");

        var actual = builder.Trigger.WhenInStates;

        actual.Count.ShouldBe(4);
    }
}