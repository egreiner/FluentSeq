namespace FluentSeq.Builder;

/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IStateBuilder<TState>: ISequenceBuilder<TState>, IActionBuilder<TState>
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
}