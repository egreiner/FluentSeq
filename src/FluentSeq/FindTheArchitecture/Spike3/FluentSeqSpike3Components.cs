#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentSeq.FindTheArchitecture.Spike3;

using System;

/// <summary>
/// This is the root element for this library
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class FluentSeq<TState>
{
    public ISequenceBuilder<TState> Create(TState initialState) => new SequenceBuilder<TState>();
}

/// <summary>
/// Provides methods for configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    // public SequenceBuilder(TState initialState)
    // {
    //     throw new NotImplementedException();
    // }

    public IStateBuilder<TState> State(TState state) => null;

    public virtual ISequenceBuilder<TState> Builder() => this;
}


/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class StateBuilder<TState>(ISequenceBuilder<TState> sequenceBuilder)
    : SequenceBuilder<TState>, IStateBuilder<TState>
{
    public override ISequenceBuilder<TState> Builder() => sequenceBuilder;


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