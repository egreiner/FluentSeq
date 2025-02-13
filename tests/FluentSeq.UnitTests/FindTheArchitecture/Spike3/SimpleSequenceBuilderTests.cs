namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using Exceptions;
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
    public void ConfigureState_ShouldThrow_when_adding_states_with_same_name()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .ConfigureState("State1");

        var actual = action.ShouldThrow<DuplicateStateException>();

        actual.Message.ShouldContain("State1");
    }


    [Fact]
    public void RegisteredStates_ShouldHave_one_RegisteredState()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .Builder();

        var actual = builder.RegisteredStates;

        actual.ShouldNotBeEmpty();
        actual.ShouldHaveSingleItem();
    }


    [Fact]
    public void RegisteredStates_ShouldHave_two_RegisteredStates()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1")
            .ConfigureState("State2")
            .Builder();

        var actual = builder.RegisteredStates;

        actual.ShouldNotBeEmpty();
        actual.Count.ShouldBe(2);
    }


    [Fact]
    public void RegisteredStates_ShouldContainEach_RegisteredState()
    {
        var builder = new FluentSeq<string>().Create("INIT");
        var stateBuilder1 = builder.ConfigureState("State1");
        var stateBuilder2 = builder.ConfigureState("State2");

        var actual = builder.RegisteredStates;

        actual.ShouldNotContain(new State("INIT"));

        actual.ShouldContain(stateBuilder1.State);
        actual.ShouldContain(stateBuilder2.State);
    }
}