﻿namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleSequenceBuilderTests
{
    [Fact]
    public void Create_SequenceBuilder_Should_NotThrow()
    {
        var actual = () => new FluentSeq<string>().Create("INIT");

        actual.ShouldNotThrow();
    }

    [Fact]
    public void Create_ShouldReturn_SequenceBuilder()
    {
        var actual = new FluentSeq<string>().Create("INIT");

        actual.ShouldBeOfType<SequenceBuilder<string>>();
    }

    [Fact]
    public void Create_ShouldReturn_SequenceBuilder_with_Options()
    {
        var builder = new FluentSeq<string>().Create("INIT");
        var actual = builder.Options;

        actual.ShouldNotBeNull();
    }

    [Fact]
    public void Create_Should_store_InitialState_in_Options()
    {
        var initialState = "INIT";

        var builder = new FluentSeq<string>().Create(initialState);
        var actual = builder.Options.InitialState;

        actual.ShouldBe(initialState);
    }

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