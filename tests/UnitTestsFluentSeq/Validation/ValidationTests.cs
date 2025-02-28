namespace UnitTestsFluentSeq.Validation;

using FluentValidation;

public sealed class ValidationTests
{
    [Fact]
    public void Builder_ShouldThrow_ToFewStatesException()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("more than one states");
    }

    [Fact]
    public void Builder_ShouldNotThrow_ToFewStatesException()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT", "State1")
            .ConfigureState("INIT")
            .ConfigureState("State1");

        var action = () => builder.Build();

        _ = action.ShouldNotThrow();
    }
}