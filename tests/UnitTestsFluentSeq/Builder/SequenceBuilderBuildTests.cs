namespace UnitTestsFluentSeq.Builder;

public sealed class SequenceBuilderBuildTests
{
    [Fact]
    public void Build_ShouldNotThrow()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }

    [Fact]
    public void Build_ShouldReturn_Sequence()
    {
        var actual = new FluentSeq<string>().Create("INIT")
            .DisableValidation()
            .Build();

        actual.ShouldBeAssignableTo<ISequence<string>>();
        actual.ShouldBeOfType<Sequence<string>>();
    }

    [Fact]
    public void Sequence_ShouldHave_Options()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .DisableValidation()
            .Build();

        var actual = sequence.Options;

        actual.ShouldNotBeNull();
    }

    [Fact]
    public void Sequence_ShouldHave_RegisteredStates()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .DisableValidation()
            .Build();

        var actual = sequence.RegisteredStates;

        actual.ShouldNotBeNull();
        actual.ShouldBeEmpty();
    }

    [Fact]
    public void Sequence_CurrentState_ShouldBe_init()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .DisableValidation()
            .Build();

        var actual = sequence.CurrentState;

        actual.ShouldBe("INIT");
    }
}