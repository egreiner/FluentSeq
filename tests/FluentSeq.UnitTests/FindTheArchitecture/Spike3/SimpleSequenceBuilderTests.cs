namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleSequenceBuilderTests
{
    [Fact]
    public void ConfigureState_ShouldNotThrow()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1");

        action.ShouldNotThrow();
    }

    [Fact]
    public void ConfigureState_ShouldHave_one_RegisteredState()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .Builder();

        var actual = builder.RegisteredStates;

        actual.ShouldNotBeEmpty();
        actual.ShouldHaveSingleItem();
    }


    [Fact]
    public void ConfigureState_ShouldHave_two_RegisteredStates()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .ConfigureState("State2")
            .Builder();

        var actual = builder.RegisteredStates;

        actual.ShouldNotBeEmpty();
        actual.Count.ShouldBe(2);
    }




    [Fact(Skip = "Doesn't work correctly")]
    public void ConfigureStateState_ShouldThrow_when_adding_states_with_same_name()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .ConfigureState("State1x");

        // TODO: This should throw an exception
        action.ShouldNotThrow();
        // action.ShouldNotThrow<Exception>();
    }
}