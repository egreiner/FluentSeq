namespace FluentSeq.Validation;

using Builder;
using Extensions;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// The initial state validator.
/// </summary>
public sealed class InitialStateValidator<TState> : HandlerValidatorBase, IHandlerValidator<TState>
{
    /// <inheritdoc />
    public bool Validate(ValidationContext<ISequenceBuilder<TState>> context, ValidationResult result)
    {
        var builder = context.InstanceToValidate;
        if (!builder.IsStateValidationRequired(builder.Options.InitialState)) return true;

        if (builder.Options.InitialState == null || builder.Options.InitialState.Equals(default(TState)))
            result.AddError("InitialState", "The Initial-State must be defined");

        // if (!HandlerIsValidated(builder))
        //     result.AddError("InitialState", "The Initial-State must have an StateTransition counterpart");

        return result.IsValid;
    }

    private bool HandlerIsValidated(IHandlerValidator<TState> builder) => true;
        // builder.Data.Handler.OfType<StateTransitionHandler>().Any(x => builder.Configuration.InitialState == x.FromState) ||
        // builder.Data.Handler.OfType<ContainsStateTransitionHandler>().Any(x => builder.Configuration.InitialState.Contains(x.FromStateContains)) ||
        // builder.Data.Handler.OfType<AnyStateTransitionHandler>().Any(x => x.FromStates.Contains(builder.Configuration.InitialState));
}