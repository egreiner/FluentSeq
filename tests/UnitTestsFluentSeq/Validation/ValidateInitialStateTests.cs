namespace UnitTestsFluentSeq.Validation;

using FluentValidation;

public sealed class ValidateInitialStateTests
{
    [Fact]
    public void Builder_ShouldThrow_InitialStateEmpty_when_Empty()
    {
        var builder = new FluentSeq<string>().Create("")
            .DisableValidationForStates("", "State1")
            .ConfigureState("")
            .ConfigureState("State1")
            .Builder();

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("InitialState");
        actual.Message.ShouldContain("must not be empty");
    }

    [Fact]
    public void Builder_ShouldThrow_InitialStateEmpty_when_null()
    {
        var builder = new FluentSeq<string>().Create(null!)
            .DisableValidationForStates("", "State1")
            .ConfigureState(null!)
            .ConfigureState("State1")
            .Builder();

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("must not be empty");
    }


    [Fact]
    public void Builder_ShouldThrow_InitialStateNotConfigured()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("State1", "State2")
            .ConfigureState("State1")
            .ConfigureState("State2")
            .Builder();

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("InitialState must be configured");
    }
}