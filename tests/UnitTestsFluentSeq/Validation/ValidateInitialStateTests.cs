namespace UnitTestsFluentSeq.Validation;

using FluentValidation;
using Builder;

public sealed class ValidateInitialStateTests
{
    [Fact]
    public void Build_ShouldThrow_InitialStateEmpty_when_Empty()
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
    public void Build_ShouldThrow_InitialStateEmpty_when_null()
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
    public void Build_ShouldThrow_InitialStateNotConfigured()
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


    [Fact]
    public void SequenceBuilder_with_enum_states_ShouldNotThrow_InitialStateNotConfigured()
    {
        var builder = new FluentSeq<TestState>().Create(TestState.Init)
            .DisableValidationForStates(TestState.State1, TestState.State2)
            .ConfigureState(TestState.Init).TriggeredBy(() => false)
            .ConfigureState(TestState.State1)
            .ConfigureState(TestState.State2)
            .Builder();

        var action = () => builder.Build();

        action.ShouldNotThrow();
    }
}