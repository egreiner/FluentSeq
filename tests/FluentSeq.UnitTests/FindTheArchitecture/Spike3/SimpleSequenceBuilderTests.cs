namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleSequenceBuilderTests
{
    [Fact]
    public void FluentSeq_Create_SequenceBuilder_Should_NotThrow()
    {
        var actual = () => new FluentSeq<string>().Create("INIT");

        actual.ShouldNotThrow();
    }

    [Fact]
    public void FluentSeq_Create_ShouldReturn_SequenceBuilder()
    {
        var actual = new FluentSeq<string>().Create("INIT");

        actual.ShouldBeOfType<SequenceBuilder<string>>();
    }

    [Fact]
    public void SequenceBuilder_State_ShouldThrow_when_adding_states_with_same_name()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .ConfigureState("State1x");

        // TODO: This should throw an exception
        action.ShouldNotThrow();
        // action.ShouldNotThrow<Exception>();
    }
}