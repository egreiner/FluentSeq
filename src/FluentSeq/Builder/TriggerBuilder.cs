﻿namespace FluentSeq.Builder;

/// <summary>
/// Provides methods for further describing a trigger
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class TriggerBuilder<TState> : StateBuilder<TState>, ITriggerBuilder<TState>
{
    /// <summary>
    /// Provides methods to parametrize a trigger
    /// </summary>
    public TriggerBuilder(IStateBuilder<TState> stateBuilder, Func<bool> triggeredByFunc) : base(stateBuilder.Builder(), stateBuilder.State.State, stateBuilder.State.Description)
    {
        RootSequenceBuilder = stateBuilder.Builder();
        RootStateBuilder    = stateBuilder.RootStateBuilder;
        Trigger             = new Trigger<TState>(stateBuilder, triggeredByFunc);
    }


    /// <inheritdoc />
    public Trigger<TState> Trigger { get; }

    /// <inheritdoc />
    public ITriggerBuilder<TState> WhenInState(TState state)
    {
        Trigger.WhenInStates.Add(state);
        return this;
    }

    /// <inheritdoc />
    public ITriggerBuilder<TState> WhenInStates(params TState[] states)
    {
        Trigger.WhenInStates.AddRange(states);
        return this;
    }
}