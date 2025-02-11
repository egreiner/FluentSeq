namespace FluentSeq.FindTheArchitecture.Spike3;

/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    private StateBuilder<TState>? _activeStateBuilder;
    private HashSet<StateBuilder<TState>> _stateBuilders = new HashSet<StateBuilder<TState>>();

    /// <summary>
    /// Creates a new instance of <see cref="SequenceBuilder{TState}"/>
    /// with a specified initial state
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    // TODO maybe injecting a complete SequenceConfiguration here would be better, that makes everything more open
    public SequenceBuilder(TState initialState)
    {
        InitialState = initialState;
        RootSequenceBuilder = this;
    }

    /// <inheritdoc />
    public TState InitialState { get; }

    /// <inheritdoc />
    public IList<State> RegisteredStates => _stateBuilders?.Select(x => x.State).ToList() ?? [];



    /// <summary>
    /// The root SequenceBuilder
    /// </summary>
    protected ISequenceBuilder<TState> RootSequenceBuilder { get; set; }


    /// <inheritdoc />
    public IStateBuilder<TState> ConfigureState(TState state, string description = "")
    {
        _activeStateBuilder = new StateBuilder<TState>(Builder(), state?.ToString() ?? string.Empty, description);

        // if (_stateBuilders.Contains(_activeStateBuilder))
//            throw new Exception();

        _stateBuilders.Add(_activeStateBuilder);

        return _activeStateBuilder;
    }


    /// <inheritdoc />
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;
}