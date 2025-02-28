﻿namespace FluentSeq.Validation;

using Builder;
using FluentValidation;
using FluentValidation.Results;

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
        RuleFor(builder => builder.RegisteredStates.Count).GreaterThan(1).WithMessage("The sequence must have more than one states");
        // RuleFor(builder => builder.Options.InitialState).NotEmpty();
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