namespace UnitTestsFluentSeq.Validation;

using FluentValidation;

public sealed class ValidateTriggerWhenInStatesTests
{
    [Fact]
    public void Build_ShouldNotThrow_StateNotConfigured()
    {
        var builder = new FluentSeq<string>().Create("State1")
            .ConfigureState("State1")
                .TriggeredBy(() => false).WhenInState("State2")
            .ConfigureState("State2")
                .TriggeredBy(() => false).WhenInState("State1")
            .Builder();

        var action = () => builder.Build();

        action.ShouldNotThrow();
    }

    [Fact]
    public void Build_ShouldThrow_StateNotConfigured()
    {
        var builder = new FluentSeq<string>().Create("State1")
            .ConfigureState("State1")
                .TriggeredBy(() => false).WhenInState("State2")
            .ConfigureState("State2")
                .TriggeredBy(() => false).WhenInState("StateX")
            .Builder();

        var action = () => builder.Build();

        // action.ShouldNotThrow();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("WhenInStates");
        actual.Message.ShouldContain("forget to configure this State");
        actual.Message.ShouldContain("typo");
        actual.Message.ShouldContain("StateX");
    }


    [Fact]
    public void Build_ShouldThrow_StateNotConfigured_when_stateValidation_is_disabled()
    {
        // because it does not make any sense to use WhenInState with a state that is not configured!

        var builder = new FluentSeq<string>().Create("State1")
            .DisableValidationForStates("StateX")
            .ConfigureState("State1")
            .TriggeredBy(() => false).WhenInState("State2")
            .ConfigureState("State2")
            .TriggeredBy(() => false).WhenInState("StateX")
            .Builder();

        var action = () => builder.Build();

        // action.ShouldNotThrow();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("WhenInStates");
        actual.Message.ShouldContain("forget to configure this State");
        actual.Message.ShouldContain("typo");
        actual.Message.ShouldContain("StateX");
    }
}