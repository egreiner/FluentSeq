namespace FluentSeq;

/// <summary>
/// The sequence configuration
/// </summary>
public class SequenceOptions<TState>
{
    /// <summary>
    /// The complete validation of the sequence configuration will be disabled
    /// </summary>
    public bool DisableValidation { get; set; }

    /// <summary>
    /// The validation for the specified states within the sequence configuration will be disabled
    /// </summary>
    public IEnumerable<TState> DisableValidationForStates { get; set; } = [];


    /// <summary>
    /// The state the sequence will start from
    /// </summary>
    public TState InitialState { get; set; } = default!;


    // TODO move this to SequenceData, or the Sequence itself
    // /// <summary>
    // /// Is an empty sequence.
    // /// On run nothing happens.
    // /// No state changes.
    // /// Validation is disabled.
    // /// </summary>
    // public bool IsEmpty { get; set; }
}