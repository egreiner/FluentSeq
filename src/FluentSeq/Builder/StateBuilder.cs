namespace FluentSeq.Builder;

/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class StateBuilder<TState> : SequenceBuilder<TState>, IStateBuilder<TState>
{
    /// <summary>
    /// Provides methods for further describing a state
    /// </summary>
    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder, TState state, string description): base(sequenceBuilder.Options.InitialState)
    {
        RootSequenceBuilder = sequenceBuilder;
        State = new SeqState<TState>(state, description);
    }

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
        State.Trigger.Add(triggerBuilder.Trigger);

        return triggerBuilder;
    }



    // public IStateBuilder<TState> OnEntry(Action action) => throw new NotImplementedException();
    //
    // public IStateBuilder<TState> OnExit(Action action) => throw new NotImplementedException();
    //
    // public IStateBuilder<TState> WhileInState(Action action) => throw new NotImplementedException();
}