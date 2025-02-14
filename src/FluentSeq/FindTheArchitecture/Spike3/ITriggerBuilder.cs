#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FluentSeq.FindTheArchitecture.Spike3;

/// <summary>
/// Provides methods for further describing a trigger
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ITriggerBuilder<TState>: IStateBuilder<TState>
{
    ITriggerBuilder<TState> WhenInState(TState state);

    ITriggerBuilder<TState> WhenInStates(params TState[] currentStates);

    /// <summary>
    /// Returns the trigger the builder is for
    /// </summary>
    Trigger<TState> Trigger { get; }
}
