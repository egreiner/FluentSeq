namespace FluentSeq.UnitTests.Extensions;

using FluentSeq.Extensions;

public sealed class SequenceBuilderExtensionsTests
{
    [Fact]
    public void ValidationRequiredFor_ShouldBeTrue()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.ValidationRequiredFor("INIT");

        actual.ShouldBeTrue();
    }

    [Fact]
    public void ValidationRequiredFor_ShouldBeFalse_when_DisableValidationForStates()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT");

        var actual = builder.ValidationRequiredFor("INIT");

        actual.ShouldBeFalse();
    }

    [Fact]
    public void ValidationRequiredFor_ShouldBeFalse_when_DisableValidation()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidation();

        var actual = builder.ValidationRequiredFor("INIT");

        actual.ShouldBeFalse();
    }


    [Fact]
    public void NoValidationRequiredFor_ShouldBeTrue()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.NoValidationRequiredFor("INIT");

        actual.ShouldBeFalse();
    }

    [Fact]
    public void NoValidationRequiredFor_ShouldBeFalse_when_DisableValidationForStates()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT");

        var actual = builder.NoValidationRequiredFor("INIT");

        actual.ShouldBeTrue();
    }

    [Fact]
    public void NoValidationRequiredFor_ShouldBeFalse_when_DisableValidation()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidation();

        var actual = builder.NoValidationRequiredFor("INIT");

        actual.ShouldBeTrue();
    }

}