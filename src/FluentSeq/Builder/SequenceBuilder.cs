namespace FluentSeq.Builder;

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
        Options.InitialState = initialState;
        RootSequenceBuilder  = this;
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

        var result = new Sequence<TState>(RootSequenceBuilder.Options, RootSequenceBuilder.RegisteredStates);
        return result;
    }

    public ISequenceBuilder<TState> ValidateAndThrow()
    {
        if (!RootSequenceBuilder.Options.DisableValidation)
            _validator.ValidateAndThrow(this);

        return this;
    }


    /// <inheritdoc />
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;



    /// <inheritdoc />
    public ISequenceBuilder<TState> DisableValidation()
    {
        RootSequenceBuilder.Options.DisableValidation = true;
        return this;
    }

    /// <inheritdoc />
    public ISequenceBuilder<TState> DisableValidationForStates(params TState[] states)
    {
        RootSequenceBuilder.Options.DisableValidationForStates = states;
        return this;
    }

    // TODO not completed
    /// <inheritdoc />
    public IStateBuilder<TState> ConfigureState(TState state, string description = "")
    {
        var builder   = new StateBuilder<TState>(Builder(), state, description);

        if (!RootSequenceBuilder.StateBuilders.Add(builder))
            throw new DuplicateStateException(builder.State.Name);

        return builder;
    }
}