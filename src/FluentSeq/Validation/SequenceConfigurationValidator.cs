namespace FluentSeq.Validation;

using Builder;
using Extensions;
using FluentValidation;

/// <summary>
/// The sequence configuration validator.
/// </summary>
public sealed class SequenceConfigurationValidator<TState> : AbstractValidator<ISequenceBuilder<TState>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SequenceConfigurationValidator{TState}"/> class.
    /// </summary>
    public SequenceConfigurationValidator()
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        AddRulesForMinimumStateCount();
        AddRulesForInitialState();
        AddRulesForConfiguredStates();
    }

    private void AddRulesForMinimumStateCount()
    {
        RuleFor(builder => builder.Builder().RegisteredStates.Count)
            .GreaterThan(1)
            .WithMessage("The sequence must have more than one state.");
    }

    private void AddRulesForInitialState()
    {
        RuleFor(builder => builder.Builder().Options.InitialState).NotEmpty();

        RuleFor(builder => builder.Builder().RegisteredStates)
            .Must((builder, registeredStates) => registeredStates.Contains(builder.Options.InitialState))
            .WithMessage("The InitialState must be configured.");
    }

    private void AddRulesForConfiguredStates()
    {
        RuleForEach(builder => builder.Builder().RegisteredStates)
            .Must((builder, state) => builder.Builder().NoValidationRequiredFor(state.State) || state.Trigger.Count > 0)
            .WithMessage((builder, state) => $"The state {state.State} must have at least one trigger.");
    }
}