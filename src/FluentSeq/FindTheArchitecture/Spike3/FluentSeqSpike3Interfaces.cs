#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentSeq.FindTheArchitecture.Spike3;

using System;

/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ISequenceBuilder<in TState>
{
    IStateBuilder<TState> State(TState state);

    ISequenceBuilder<TState> Builder();
}

/// <summary>
/// Provides methods to enhance a state with actions
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IActionBuilder<in TState>
{
    IStateBuilder<TState> OnEntry(Action action);

    IStateBuilder<TState> OnExit(Action action);

    IStateBuilder<TState> WhileInState(Action action);
}


/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IStateBuilder<in TState>: ISequenceBuilder<TState>, IActionBuilder<TState>
{
    ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc);
}


/// <summary>
/// Provides methods for further describing a trigger
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ITriggerBuilder<in TState>: IStateBuilder<TState>
{
    ITriggerBuilder<TState> WhenInState(TState currentState);

    ITriggerBuilder<TState> WhenInStates(params TState[] currentStates);
}
