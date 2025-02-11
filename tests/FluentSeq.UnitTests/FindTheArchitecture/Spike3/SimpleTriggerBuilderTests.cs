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
}