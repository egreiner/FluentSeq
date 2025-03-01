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

        actual.Message.ShouldContain("more than one state");
    }

    [Fact]
    public void Builder_ShouldNotThrow_ToFewStatesException()
    {
        var builder = new FluentSeq<string>().Create("INIT")
            .DisableValidationForStates("INIT", "State1")
            .ConfigureState("INIT")
                .TriggeredBy(() => false)
            .ConfigureState("State1")
                .TriggeredBy(() => false)
            .Builder();


        var action = () => builder.Build();

        _ = action.ShouldNotThrow();
    }


    [Fact]
    public void Builder_ShouldThrow_InitialStateEmpty_when_Empty()
    {
        var builder = new FluentSeq<string>().Create("")
            .DisableValidationForStates("", "State1")
            .ConfigureState("")
                .TriggeredBy(() => false)
            .ConfigureState("State1")
                .TriggeredBy(() => false)
            .Builder();

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("must not be empty");
    }

    [Fact]
    public void Builder_ShouldThrow_InitialStateEmpty_when_null()
    {
        var builder = new FluentSeq<string>().Create(null)
            .DisableValidationForStates("", "State1")
            .ConfigureState(null)
                .TriggeredBy(() => false)
            .ConfigureState("State1")
                .TriggeredBy(() => false)
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
                .TriggeredBy(() => false)
            .ConfigureState("State2")
                .TriggeredBy(() => false)
            .Builder();

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("InitialState must be configured");
    }
}