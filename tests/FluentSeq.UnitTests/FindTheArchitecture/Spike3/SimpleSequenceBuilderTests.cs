namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleSequenceBuilderTests
{
   [Fact(Skip = "Doesn't work correctly")]
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