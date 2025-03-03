namespace FluentSeq.Builder;

/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IStateBuilder<TState>: IHasSequenceBuilder<TState>, ICanConfigureState<TState>, ICanConfigureActions<TState>
{
    /// <summary>
    /// The state that the builder should parameterize
    /// </summary>
    SeqState<TState> State { get; }

    /// <summary>
    /// The root state builder
    /// </summary>
    StateBuilder<TState> RootStateBuilder { get; }


    /// <summary>
    /// The sequence can be forced to this state when the state is triggered by a function
    /// </summary>
    /// <param name="triggeredByFunc">The trigger-function</param>
    ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc);

    /// <summary>
    /// The sequence can be forced to this state when the current state of the sequence is the specified state for the specified time
    /// </summary>
    /// <param name="state">The condition of the current state of the sequence</param>
    /// <param name="dwellTime">For how long the sequence must be in this state before the trigger gets valid</param>
    ITriggerBuilder<TState> TriggeredByState(TState state, Func<TimeSpan> dwellTime);
}