namespace FluentSeq.Builder;

using Core;
using Exceptions;
using FluentValidation;
using Validation;

/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    private readonly SequenceConfigurationValidator<TState> _validator = new();


    /// <summary>
    /// Creates a new instance of <see cref="SequenceBuilder{TState}"/>
    /// with a specified initial state
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    public SequenceBuilder(TState initialState)
    {
        RootSequenceBuilder  = this;
        Options.InitialState = initialState;
    }
    

    /// <inheritdoc />
    public SequenceOptions<TState> Options { get; } = new();


    /// <inheritdoc />
    public HashSet<StateBuilder<TState>> StateBuilders { get; } = new();


    /// <inheritdoc />
    public SeqStateCollection<TState> RegisteredStates =>
        new(Builder().StateBuilders.Select(x => x.State));


    /// <summary>
    /// The root SequenceBuilder
    /// </summary>
    protected ISequenceBuilder<TState> RootSequenceBuilder { get; set; }



    /// <inheritdoc />
    public ISequence<TState> Build()
    {
        ValidateAndThrow();

        var result = new Sequence<TState>(Builder().Options, Builder().RegisteredStates);
        return result;
    }

    private ISequenceBuilder<TState> ValidateAndThrow()
    {
        if (!Builder().Options.DisableValidation)
            _validator.ValidateAndThrow(this);

        return this;
    }


    /// <inheritdoc />
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;



    /// <inheritdoc />
    public ISequenceBuilder<TState> DisableValidation()
    {
        Builder().Options.DisableValidation = true;
        return this;
    }

    /// <inheritdoc />
    public ISequenceBuilder<TState> DisableValidationForStates(params TState[] states)
    {
        Builder().Options.DisableValidationForStates = states;
        return this;
    }

    /// <inheritdoc />
    public IStateBuilder<TState> ConfigureState(TState state, string description = "")
    {
        var builder = new StateBuilder<TState>(Builder(), state, description);

        if (!Builder().StateBuilders.Add(builder))
            throw new DuplicateStateException(builder.State.Name);

        return builder;
    }
}