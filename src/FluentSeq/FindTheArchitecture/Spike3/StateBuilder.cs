namespace FluentSeq.FindTheArchitecture.Spike3;

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
    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder, string stateName): base(sequenceBuilder.InitialState)
    {
        RootSequenceBuilder = sequenceBuilder;
        StateX = new State(stateName);
    }

    /// <inheritdoc />
    public State StateX { get; }


    public ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc) => throw new NotImplementedException();

    public IStateBuilder<TState> OnEntry(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> OnExit(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> WhileInState(Action action) => throw new NotImplementedException();
}