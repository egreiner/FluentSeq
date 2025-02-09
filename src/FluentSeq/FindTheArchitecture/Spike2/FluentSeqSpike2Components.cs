namespace FluentSeq.FindTheArchitecture.Spike2;

using System;

/// <summary>
/// This is the root element for this library
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceFactory<TState>
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

    public IStateBuilder<TState> State(TState state) => throw new NotImplementedException();

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
public class TriggerBuilder<TState>(ISequenceBuilder<TState> sequenceBuilder)
    : StateBuilder<TState>(sequenceBuilder), ITriggerBuilder<TState>
{
    //
    // public override ISequenceBuilder<TState> Builder() => _sequenceBuilder;

    public ITriggerBuilder<TState> WhenInState(TState currentState) => throw new NotImplementedException();

    public ITriggerBuilder<TState> WhenInStates(params TState[] currentStates) => throw new NotImplementedException();
}