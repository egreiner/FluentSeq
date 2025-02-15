namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

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
}