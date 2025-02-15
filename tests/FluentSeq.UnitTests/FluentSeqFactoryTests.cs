namespace FluentSeq.UnitTests;

using FluentSeq.Builder;

public sealed class FluentSeqFactoryTests
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


    [Fact]
    public void DisableValidation_ShouldBeFalse_per_default()
    {
        var builder = new FluentSeq<string>().Create("INIT");
        var actual = builder.Options.DisableValidation;

        actual.ShouldBeFalse();
    }

    [Fact]
    public void DisableValidation_ShouldBe_stored_in_Options()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        builder.DisableValidation();

        var actual = builder.Options.DisableValidation;
        actual.ShouldBeTrue();
    }

    [Fact]
    public void DisableValidationForStates_ShouldBeNull_per_default()
    {
        var builder = new FluentSeq<string>().Create("INIT");
        var actual = builder.Options.DisableValidationForStates;

        actual.ShouldBeEmpty();
    }


    [Fact]
    public void DisableValidationForStates_ShouldBe_stored_in_Options()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        builder.DisableValidationForStates("State_A", "State_B");
        var actual = builder.Options.DisableValidationForStates.ToList();

        actual.ShouldNotContain("INIT");
        actual.ShouldContain("State_A");
        actual.ShouldContain("State_B");
    }
}