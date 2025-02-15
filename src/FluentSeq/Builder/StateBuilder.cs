namespace FluentSeq.Builder;

#pragma warning disable CS1591
/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class StateBuilder<TState> : SequenceBuilder<TState>, IStateBuilder<TState>
{
    /// <summary>
    /// Provides methods for further describing a state
    /// </summary>
    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder, string stateName, string description): base(sequenceBuilder.Options.InitialState)
    {
        RootSequenceBuilder = sequenceBuilder;
        State = new State(stateName, description);
    }

    /// <inheritdoc />
    public State State { get; }


    /// <inheritdoc />
    public override string ToString() =>
        $"StateBuilder for State: {State.Name} {State.Description}";


    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is StateBuilder<TState> stateBuilder && State.Equals(stateBuilder.State);

    /// <inheritdoc />
    public override int GetHashCode() =>
        State.Name.GetHashCode();



    public ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc) =>
        new TriggerBuilder<TState>(this);

    // public IStateBuilder<TState> OnEntry(Action action) => throw new NotImplementedException();
    //
    // public IStateBuilder<TState> OnExit(Action action) => throw new NotImplementedException();
    //
    // public IStateBuilder<TState> WhileInState(Action action) => throw new NotImplementedException();
}