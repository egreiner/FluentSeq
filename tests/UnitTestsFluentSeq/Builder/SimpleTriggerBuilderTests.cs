namespace UnitTestsFluentSeq.Builder;

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
        var trigger        = triggerBuilder.Trigger;

        var actual = stateBuilder.State.Trigger;
        actual.ShouldContain(trigger);
    }

    [Fact]
    public void TriggerBuilder_ShouldAdd_all_Trigger_to_state()
    {
        var stateBuilder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1");

        var triggerBuilder1 = stateBuilder.TriggeredBy(() => true);
        var trigger1        = triggerBuilder1.Trigger;

        var triggerBuilder2 = stateBuilder.TriggeredBy(() => false);
        var trigger2        = triggerBuilder2.Trigger;

        var actual = stateBuilder.State.Trigger;
        actual.ShouldContain(trigger1);
        actual.ShouldContain(trigger2);
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
    public void WhenInState_with_TimeSpan_ShouldCreate_one_element()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .TriggeredBy(() => true)
            .WhenInState("Bla", () => TimeSpan.FromMilliseconds(20));

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

    [Fact]
    public void TwoTriggeredBy_ShouldCreate_two_elements()
    {
        var stateBuilder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1");

        stateBuilder.TriggeredBy(() => true).WhenInState("Bla")
            .TriggeredBy(() => false).WhenInState("Blub");

        var actual = stateBuilder.State.Trigger;

        actual.Count.ShouldBe(2);
    }

    [Fact]
    public void TriggeredBy_andTriggeredByState_ShouldCreate_two_elements()
    {
        var stateBuilder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1");

        stateBuilder.TriggeredBy(() => true).WhenInState("Bla")
                    .TriggeredByState("INIT", () => TimeSpan.FromMilliseconds(20));

        var actual = stateBuilder.State.Trigger;

        actual.Count.ShouldBe(2);
    }
}