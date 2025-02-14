namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

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
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true);

        var actual = trigger.Trigger;

        actual.ShouldNotBeNull();
    }

    [Fact]
    public void Trigger_WhenInStates_ShouldBeEmpty_per_default()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true);

        var actual = trigger.Trigger.WhenInStates;

        actual.ShouldBeEmpty();
    }

    [Fact]
    public void WhenInState_ShouldCreate_one_element()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla");

        var actual = trigger.Trigger.WhenInStates;

        actual.ShouldHaveSingleItem();
    }

    [Fact]
    public void WhenInState_ShouldCreate_two_elements()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla")
            .WhenInState("Blub");

        var actual = trigger.Trigger.WhenInStates;

        actual.Count.ShouldBe(2);
    }

    [Fact]
    public void WhenInStates_ShouldCreate_one_element()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInStates("Bla");

        var actual = trigger.Trigger.WhenInStates;

        actual.ShouldHaveSingleItem();
    }

    [Fact]
    public void WhenInStates_ShouldCreate_four_elements()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInStates("Bla", "Blub", "Fizz", "Buzz");

        var actual = trigger.Trigger.WhenInStates;

        actual.Count.ShouldBe(4);
    }


    [Fact]
    public void Combined_WhenInState_and_WhenInStates_ShouldCreate_four_elements()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla")
            .WhenInStates("Blub", "Fizz", "Buzz");

        var actual = trigger.Trigger.WhenInStates;

        actual.Count.ShouldBe(4);
    }
}