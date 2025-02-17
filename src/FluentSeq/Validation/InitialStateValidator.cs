namespace FluentSeq.Validation;

using Builder;
using Extensions;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// The initial state validator.
/// </summary>
public sealed class InitialStateValidator<TState> : ValidatorBase, IValidator<TState>
{
    /// <inheritdoc />
    public bool Validate(ValidationContext<ISequenceBuilder<TState>> context, ValidationResult result)
    {
        var builder = context.InstanceToValidate;
        var state   = builder.Options.InitialState;

        if (builder.NoValidationRequiredFor(state)) return true;

        if (state == null || state.Equals(default(TState)))
        {
            result.AddError("InitialState", "The Initial-State must be not null");
            return result.IsValid;
        }

        if (!builder.RegisteredStates.Contains(new SeqState<TState>(state)))
            result.AddError("InitialState", $"The Initial-State '{state}' must be configured");

        // if (!HandlerIsValidated(builder))
        //     result.AddError("InitialState", "The Initial-State must have an StateTransition counterpart");

        return result.IsValid;
    }

    private bool HandlerIsValidated(IValidator<TState> builder) => true;
        // builder.Data.Handler.OfType<StateTransitionHandler>().Any(x => builder.Configuration.InitialState == x.FromState) ||
        // builder.Data.Handler.OfType<ContainsStateTransitionHandler>().Any(x => builder.Configuration.InitialState.Contains(x.FromStateContains)) ||
        // builder.Data.Handler.OfType<AnyStateTransitionHandler>().Any(x => x.FromStates.Contains(builder.Configuration.InitialState));
}