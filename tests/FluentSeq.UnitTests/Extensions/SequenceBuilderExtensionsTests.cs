namespace FluentSeq.UnitTests.Extensions;

using FluentSeq.Extensions;

public class SequenceBuilderExtensionsTests
{
    [Fact]
    public void StateShouldBeValidated_ShouldBeTrue()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.StateShouldBeValidated("INIT");

        actual.ShouldBeTrue();
    }

    [Fact]
    public void StateShouldBeValidated_ShouldBeFalse_when_DisableValidationForStates()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT");

        var actual = builder.StateShouldBeValidated("INIT");

        actual.ShouldBeFalse();
    }

    [Fact]
    public void StateShouldBeValidated_ShouldBeFalse_when_DisableValidation()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidation();

        var actual = builder.StateShouldBeValidated("INIT");

        actual.ShouldBeFalse();
    }
}