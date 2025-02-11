#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentSeq.FindTheArchitecture.Spike3;

using System;

/// <summary>
/// Provides methods for further describing a trigger
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class TriggerBuilder<TState> : StateBuilder<TState>, ITriggerBuilder<TState>
{
    private readonly IStateBuilder<TState> _stateBuilder;

    /// <summary>
    /// Provides methods to parametrize a trigger
    /// </summary>
    public TriggerBuilder(IStateBuilder<TState> stateBuilder) : base(stateBuilder.Builder(), stateBuilder.State.Name, stateBuilder.State.Description)
    {
        RootSequenceBuilder = stateBuilder.Builder();
        Trigger = new Trigger<TState>(stateBuilder);
    }


    /// <inheritdoc />
    public Trigger<TState> Trigger { get; }


    public ITriggerBuilder<TState> WhenInState(TState currentState) => throw new NotImplementedException();

    public ITriggerBuilder<TState> WhenInStates(params TState[] currentStates) => throw new NotImplementedException();
}