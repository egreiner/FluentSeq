namespace FluentSeq.UnitTests.Extensions;

using FluentSeq.Extensions;

public sealed class SequenceBuilderExtensionsTests
{
    [Fact]
    public void IsStateValidationRequired_ShouldBeTrue()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.IsStateValidationRequired("INIT");

        actual.ShouldBeTrue();
    }

    [Fact]
    public void IsStateValidationRequired_ShouldBeFalse_when_DisableValidationForStates()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT");

        var actual = builder.IsStateValidationRequired("INIT");

        actual.ShouldBeFalse();
    }

    [Fact]
    public void IsStateValidationRequired_ShouldBeFalse_when_DisableValidation()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidation();

        var actual = builder.IsStateValidationRequired("INIT");

        actual.ShouldBeFalse();
    }
}