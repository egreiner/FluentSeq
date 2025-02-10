namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class StateBuilder<TState> : IStateBuilder<TState>
{
    private readonly ISequenceBuilder<TState> _sequenceBuilder;

    /// <summary>
    /// Provides methods for further describing a state
    /// </summary>
    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder)
    {
        _sequenceBuilder = sequenceBuilder;
    }


    public IStateBuilder<TState> State(TState state) =>
        _sequenceBuilder.State(state);

    public ISequenceBuilder<TState> Builder() =>
        _sequenceBuilder;


    public ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc) => throw new NotImplementedException();

    public IStateBuilder<TState> OnEntry(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> OnExit(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> WhileInState(Action action) => throw new NotImplementedException();
}