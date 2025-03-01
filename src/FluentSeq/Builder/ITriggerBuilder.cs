#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentSeq.Builder;

/// <summary>
/// Provides methods for further describing a trigger
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ITriggerBuilder<TState>: ICanConfigureActions<TState>, ICanConfigureState<TState>, IHasSequenceBuilder<TState>
{
    /// <summary>
    /// Returns the trigger the builder is for
    /// </summary>
    Trigger<TState> Trigger { get; }

    /// <summary>
    /// Describes what CurrentState the sequence can be for the trigger to be valid.
    /// </summary>
    /// <param name="state">The condition of the current state of the sequence</param>
    ITriggerBuilder<TState> WhenInState(TState state);

    /// <summary>
    /// Describes what CurrentState the sequence must be and for how long for the trigger to be valid.
    /// </summary>
    /// <param name="state">The condition of the current state of the sequence</param>
    /// <param name="dwellTime">For how long the sequence must be in this state before the trigger gets valid</param>
    ITriggerBuilder<TState> WhenInState(TState state, TimeSpan dwellTime);

    /// <summary>
    /// Describes what CurrentStates the sequence can be for the trigger to be valid.
    /// </summary>
    /// <param name="states">The condition of the current states of the sequence</param>
    ITriggerBuilder<TState> WhenInStates(params TState[] states);
}
