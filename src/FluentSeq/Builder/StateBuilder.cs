namespace FluentSeq.Builder;

/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class StateBuilder<TState> : IStateBuilder<TState>
{
    private readonly ConfigureActions<TState> _actions;

    /// <summary>
    /// Provides methods for further describing a state
    /// </summary>
    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder, TState state, string description)
    {
        RootSequenceBuilder = sequenceBuilder.Builder();
        RootStateBuilder    = this;
        State               = new SeqState<TState>(state, description);
        _actions            = new ConfigureActions<TState>(RootStateBuilder);
    }


    /// <summary>
    /// The root SequenceBuilder
    /// </summary>
    private ISequenceBuilder<TState> RootSequenceBuilder { get; set; }

    /// <inheritdoc />
    public StateBuilder<TState> RootStateBuilder { get; protected set; }

    /// <inheritdoc />
    public SeqState<TState> State { get; }


    /// <inheritdoc />
    public override string ToString() =>
        $"StateBuilder for State: {State.Name} {State.Description}";


    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is StateBuilder<TState> stateBuilder && State.Equals(stateBuilder.State);

    /// <inheritdoc />
    public override int GetHashCode() =>
        State.Name.GetHashCode();



    /// <inheritdoc />
    public ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc)
    {
        var triggerBuilder = new TriggerBuilder<TState>(this, triggeredByFunc);
        RootStateBuilder.State.Trigger.Add(triggerBuilder.Trigger);

        return triggerBuilder;
    }

    /// <inheritdoc />
    public ITriggerBuilder<TState> TriggeredByState(TState state, Func<TimeSpan> dwellTime)
    {
        var triggerBuilder = new TriggerBuilder<TState>(this, () => true);
        triggerBuilder.WhenInState(state, dwellTime);
        RootStateBuilder.State.Trigger.Add(triggerBuilder.Trigger);

        return triggerBuilder;
    }


    /// <inheritdoc />
    public IStateBuilder<TState> OnExit(Action action) =>
        _actions.OnExit(action);

    /// <inheritdoc />
    public IStateBuilder<TState> OnEntry(Action action) =>
        _actions.OnEntry(action);

    /// <inheritdoc />
    public IStateBuilder<TState> WhileInState(Action action) =>
        _actions.WhileInState(action);


    /// <inheritdoc />
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;

    /// <inheritdoc />
    public IStateBuilder<TState> ConfigureState(TState state, string description = "") =>
        Builder().ConfigureState(state, description);
}