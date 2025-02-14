namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleTriggerBuilderTests
{
    [Fact]
    public void StateBuilder_TriggerBy_ShouldReturn_TriggerBuilder()
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
    public void Trigger_InStates_ShouldBeEmpty_per_default()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true);

        var actual = trigger.Trigger.WhenInStates;

        actual.ShouldBeEmpty();
    }

    [Fact]
    public void Trigger_InStates_ShouldContain_one_element()
    {
        var trigger = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla");

        var actual = trigger.Trigger.WhenInStates;

        actual.ShouldHaveSingleItem();
    }
}