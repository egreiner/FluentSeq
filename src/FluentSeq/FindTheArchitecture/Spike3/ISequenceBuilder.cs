namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ISequenceBuilder<TState>
{
    /// <summary>
    /// The initial state of the sequence
    /// </summary>
    TState InitialState { get; }

    /// <summary>
    /// Returns a list of all registered states
    /// </summary>
    IList<State> RegisteredStates { get; }


    /// <summary>
    /// Creates a new State
    /// </summary>
    /// <param name="state">The name of the state</param>
    /// <param name="description">Optional description of the state</param>
    /// <returns>A StateBuilder</returns>
    IStateBuilder<TState> ConfigureState(TState state, string description = "");

    /// <summary>
    /// Returns the root SequenceBuilder
    /// </summary>
    ISequenceBuilder<TState> Builder();

    // TODO public ISequence<TState> Build()
}