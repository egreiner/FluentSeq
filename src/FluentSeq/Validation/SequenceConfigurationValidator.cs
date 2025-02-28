namespace FluentSeq.Validation;

using Builder;
using FluentValidation;

/// <summary>
/// The sequence configuration validator.
/// </summary>
public sealed class SequenceConfigurationValidator<TState> : AbstractValidator<SequenceBuilder<TState>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SequenceConfigurationValidator{TState}"/> class.
    /// </summary>
    public SequenceConfigurationValidator()
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;

        RuleFor(builder => builder.RegisteredStates.Count).GreaterThan(1).WithMessage("The sequence must have more than one states");
        RuleFor(builder => builder.Options.InitialState).NotEmpty();

        // TODO
        RuleFor(builder => builder.RegisteredStates)
            .Must((builder, registeredStates) => registeredStates.Contains(builder.Options.InitialState))
            .WithMessage("The InitialState must be configured");
    }

    //
    // /// <summary>
    // /// Pre-validates the sequence configuration.
    // /// </summary>
    // /// <param name="context">The Validation context</param>
    // /// <param name="result">The validation-result</param>
    // protected override bool PreValidate(ValidationContext<SequenceBuilder> context, ValidationResult result)
    // {
    //     var isValid = true;
    //     context.InstanceToValidate.Data.Validators.ToList()
    //         .ForEach(x => isValid &= x.Validate(context, result));
    //
    //     return isValid;
    // }
}