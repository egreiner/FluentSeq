namespace FluentSeq.Builder;

using Exceptions;

/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    /// <summary>
    /// Creates a new instance of <see cref="SequenceBuilder{TState}"/>
    /// with a specified initial state
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    public SequenceBuilder(TState initialState)
    {
        Options.InitialState = initialState;
        RootSequenceBuilder = this;
    }
    

    /// <inheritdoc />
    public SequenceOptions<TState> Options { get; } = new();


    /// <inheritdoc />
    public HashSet<StateBuilder<TState>> StateBuilders { get; } = new HashSet<StateBuilder<TState>>();


    /// <inheritdoc />
    public IList<State> RegisteredStates => Builder().StateBuilders.Select(x => x.State).ToList() ?? [];


    /// <summary>
    /// The root SequenceBuilder
    /// </summary>
    protected ISequenceBuilder<TState> RootSequenceBuilder { get; set; }



    /// <inheritdoc />
    public ISequence<TState> Build()
    {
        var result = new Sequence<TState>(Options);
        return result;
    }


    /// <inheritdoc />
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;



    /// <inheritdoc />
    public ISequenceBuilder<TState> DisableValidation()
    {
        Options.DisableValidation = true;
        return this;
    }

    /// <inheritdoc />
    public ISequenceBuilder<TState> DisableValidationForStates(params TState[] states)
    {
        Options.DisableValidationForStates = states;
        return this;
    }

    // TODO not completed
    /// <inheritdoc />
    public IStateBuilder<TState> ConfigureState(TState state, string description = "")
    {
        var stateName = state?.ToString() ?? Guid.NewGuid().ToString();
        var builder   = new StateBuilder<TState>(Builder(), stateName, description);

        if (!Builder().StateBuilders.Add(builder))
            throw new DuplicateStateException(builder.State.Name);

        return builder;
    }
}