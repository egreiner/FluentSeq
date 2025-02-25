namespace FluentSeq;

// using Logging;

/// <summary>
/// Interface for a sequence
/// </summary>
public interface ISequence<TState>
{
    // // /// <summary>
    // // /// The debug logger
    // // /// </summary>
    // // ILoggerAdapter Logger { get; set; }

    // // /// <summary>
    // // /// The sequence-data
    // // /// </summary>
    // // SequenceData Data { get; }


    /// <summary>
    /// The sequence options
    /// </summary>
    SequenceOptions<TState> Options { get; }

    /// <summary>
    /// All States that are registered for this sequence
    /// </summary>
    SeqStateCollection<TState> RegisteredStates { get; }


    /// <summary>
    /// The current state of the sequence
    /// </summary>
    TState CurrentState { get; }

    /// <summary>
    /// The previous state of the sequence
    /// </summary>
    TState? PreviousState { get; }


    // // /// <summary>
    // // /// Returns true if the queried state is registered in the sequence-configuration.
    // // /// </summary>
    // // /// <param name="state">The state</param>
    // // bool IsRegisteredState(TState state);
    //
    //
    //
    // // /// <summary>
    // // /// Set the sequence-configuration
    // // /// </summary>
    // // ISequence SetConfiguration(SequenceConfiguration configuration, SequenceData data);


    /// <summary>
    /// Checks if the current state of the sequence matches the specified state.
    /// </summary>
    /// <param name="state">The state to check against the current state.</param>
    /// <returns>True if the current state matches the specified state; otherwise, false.</returns>
    bool IsInState(TState state);

    /// <summary>
    /// Checks if the current state of the sequence matches any of the specified states.
    /// </summary>
    /// <param name="states">The states to check against the current state.</param>
    /// <returns>True if the current state matches any of the specified states; otherwise, false.</returns>
    bool IsInStates(params TState[] states);

    /// <summary>
    /// Run the sequence
    /// </summary>
    ISequence<TState> Run();

    // // /// <summary>
    // // /// Runs the sequence asynchronous
    // // /// </summary>
    // // Task<ISequence<TState>> RunAsync();
    // //

    /// <summary>
    /// CurrentState will be set to the state immediately and unconditional.
    /// The execution of the sequence will continue.
    /// </summary>
    /// <param name="state">The state that will be set</param>
    ISequence<TState> SetState(TState state);

    /// <summary>
    /// If the constraint is fulfilled the CurrentState will be set to the state immediately
    /// and the execution of the sequence will continue.
    /// </summary>
    /// <param name="state">The state that should be set</param>
    /// <param name="condition">The condition that must be fulfilled that the sequence is set to the defined state</param>
    ISequence<TState> SetState(TState state, Func<bool> condition);
}