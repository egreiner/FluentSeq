namespace FluentSeq.FindTheArchitecture.Spike3;

// using Logging;

/// <summary>
/// Interface for a sequence
/// </summary>
public interface ISequence<TSTate>
{
    // // /// <summary>
    // // /// The debug logger
    // // /// </summary>
    // // ILoggerAdapter Logger { get; set; }
    //
    // /// <summary>
    // /// The sequence options
    // /// </summary>
    // SequenceOptions<TSTate> Options { get; }
    //
    // // /// <summary>
    // // /// The sequence-data
    // // /// </summary>
    // // SequenceData Data { get; }
    //
    //
    // /// <summary>
    // /// The current state of the sequence
    // /// </summary>
    // TSTate CurrentState { get; }
    //
    //
    // /// <summary>
    // /// The last state of the sequence
    // /// </summary>
    // TSTate PreviousState { get; }
    //
    // // /// <summary>
    // // /// A builtin stopwatch
    // // /// </summary>
    // // Stopwatch Stopwatch { get; }
    //
    //
    // // TODO rename to IsInState in v4.0?
    // /// <summary>
    // /// Returns true if the sequence.CurrentState is in the specified state.
    // /// </summary>
    // /// <param name="state">The state that is asked for.</param>
    // bool HasCurrentState(TSTate state);
    //
    // // // TODO rename to IsInStates or IsInAnyState in v4.0?
    // // /// <summary>
    // // /// Returns true if the sequence.CurrentState is in one of the specified states.
    // // /// </summary>
    // // /// <param name="states">The states that are asked for.</param>
    // // bool HasAnyCurrentState(params TSTate[] states);
    // //
    // // /// <summary>
    // // /// Returns true if the queried state is registered in the sequence-configuration.
    // // /// </summary>
    // // /// <param name="state">The state</param>
    // // bool IsRegisteredState(TSTate state);
    //
    //
    //
    // // /// <summary>
    // // /// Set the sequence-configuration
    // // /// </summary>
    // // ISequence SetConfiguration(SequenceConfiguration configuration, SequenceData data);
    //
    //
    // /// <summary>
    // /// Run the sequence
    // /// </summary>
    // ISequence<TSTate> Run();
    //
    // // /// <summary>
    // // /// Runs the sequence asynchronous
    // // /// </summary>
    // // Task<ISequence<TSTate>> RunAsync();
    // //
    //
    // /// <summary>
    // /// CurrentState will be set to the state immediately and unconditional.
    // /// The execution of the sequence will continue.
    // /// </summary>
    // /// <param name="state">The state that will be set</param>
    // ISequence<TSTate> SetState(TSTate state);
    //
    // /// <summary>
    // /// If the constraint is fulfilled the CurrentState will be set to the state immediately
    // /// and the execution of the sequence will continue.
    // /// </summary>
    // /// <param name="state">The state that should be set</param>
    // /// <param name="constraint">The constraint that must be fulfilled that the sequence is set to the defined state</param>
    // ISequence<TSTate> SetState(TSTate state, Func<bool> constraint);
}