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
}