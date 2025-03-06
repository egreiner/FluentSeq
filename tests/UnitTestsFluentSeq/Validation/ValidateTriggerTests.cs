namespace UnitTestsFluentSeq.Validation;

using FluentValidation;

public sealed class ValidateTriggerTests
{
    [Fact]
    public void Build_ShouldThrow_TriggerNotConfigured()
    {
        var builder = new FluentSeq<string>().Create("State1")
            .ConfigureState("State1")
            .ConfigureState("State2")
            .Builder();

        var action = () => builder.Build();

        var actual = action.ShouldThrow<ValidationException>();

        actual.Message.ShouldContain("State1");
        actual.Message.ShouldContain("State2");
        actual.Message.ShouldContain("least one trigger");
    }

    [Fact]
    public void Build_ShouldNotThrow_TriggerNotConfigured()
    {
        var builder = new FluentSeq<string>().Create("State1")
            .ConfigureState("State1")
                .TriggeredBy(() => false)
            .ConfigureState("State2")
                .TriggeredBy(() => false)
            .Builder();

        var action = () => builder.Build();

        action.ShouldNotThrow();
    }
}