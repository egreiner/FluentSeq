#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentSeq.FindTheArchitecture.Spike3;

using System;

/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class StateBuilder<TState> : SequenceBuilder<TState>, IStateBuilder<TState>
{
    private readonly ISequenceBuilder<TState> _sequenceBuilder;

    /// <summary>
    /// Provides methods for further describing a state
    /// </summary>
    /// <typeparam name="TState">The type of the state</typeparam>
    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder)
    {
        _sequenceBuilder = sequenceBuilder;
    }

    public override ISequenceBuilder<TState> Builder() => _sequenceBuilder;


    public ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc) => throw new NotImplementedException();

    public IStateBuilder<TState> OnEntry(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> OnExit(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> WhileInState(Action action) => throw new NotImplementedException();
}


/// <summary>
/// Provides methods for further describing a trigger
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class TriggerBuilder<TState> : StateBuilder<TState>, ITriggerBuilder<TState>
{
    private readonly IStateBuilder<TState> _stateBuilder;

    /// <summary>
    /// Provides methods for further describing a trigger
    /// </summary>
    public TriggerBuilder(ISequenceBuilder<TState> sequenceBuilder,IStateBuilder<TState> stateBuilder) : base(sequenceBuilder)
    {
        _stateBuilder = stateBuilder;
    }

    //
    // public override ISequenceBuilder<TState> Builder() => _sequenceBuilder;

    public ITriggerBuilder<TState> WhenInState(TState currentState) => throw new NotImplementedException();

    public ITriggerBuilder<TState> WhenInStates(params TState[] currentStates) => throw new NotImplementedException();
}