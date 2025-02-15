namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

public sealed class SequenceBuilderTests
{
    [Fact]
    public void Build_ShouldNotThrow()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .Build();

        action.ShouldNotThrow();
    }

    [Fact]
    public void Build_ShouldReturn_Sequence()
    {
        var actual = new FluentSeq<string>().Create("INIT")
            .Build();

        actual.ShouldBeAssignableTo<ISequence<string>>();
        actual.ShouldBeOfType<Sequence<string>>();
    }

    [Fact]
    public void Sequence_ShouldHave_Options()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .Build();

        var actual = sequence.Options;

        actual.ShouldNotBeNull();
    }

    [Fact]
    public void Sequence_CurrentState_ShouldBe_init()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .Build();

        var actual = sequence.CurrentState;

        actual.ShouldBe("INIT");
    }
}