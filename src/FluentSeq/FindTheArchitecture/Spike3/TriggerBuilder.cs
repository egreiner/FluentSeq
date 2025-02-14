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
        _stateBuilder = stateBuilder;
        RootSequenceBuilder = stateBuilder.Builder();
        Trigger = new Trigger<TState>(stateBuilder);
    }


    /// <inheritdoc />
    public Trigger<TState> Trigger { get; }


    /// <summary>
    /// Describes what CurrentState the sequence must be that the trigger is valid
    /// </summary>
    /// <param name="currentState">The condition of the current state of the sequence</param>
    public ITriggerBuilder<TState> WhenInState(TState currentState) => throw new NotImplementedException();

    /// <summary>
    /// Describes what CurrentStates the sequence can be that the trigger is valid
    /// </summary>
    /// <param name="currentStates">The condition of the current states of the sequence</param>
    public ITriggerBuilder<TState> WhenInStates(params TState[] currentStates) => throw new NotImplementedException();
}