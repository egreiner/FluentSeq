namespace UnitTestsFluentSeq.Validation;

using FluentValidation;

public sealed class ToFewStatesTests
{
    [Fact]
    public void Builder_ShouldThrow_ToFewStatesException()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("more than one state");
    }

    [Fact]
    public void Builder_ShouldNotThrow_ToFewStatesException()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT", "State1")
            .ConfigureState("INIT")
            .ConfigureState("State1")
            .Builder();

        var action = () => builder.Build();

        action.ShouldNotThrow();
    }
}