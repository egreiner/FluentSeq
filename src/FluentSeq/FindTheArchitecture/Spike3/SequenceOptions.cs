namespace FluentSeq.FindTheArchitecture.Spike3;

/// <summary>
/// The sequence configuration
/// </summary>
public class SequenceOptions<TState>
{
    /// <summary>
    /// The complete validation will be disabled
    /// </summary>
    public bool DisableValidation { get; set; }

    /// <summary>
    /// Does tell the validator to not check this states
    /// </summary>
    public TState[] DisableValidationForStates { get; set; } = null!;


    /// <summary>
    /// The state the sequence will start from
    /// </summary>
    public TState InitialState { get; set; }


    // TODO move this to SequenceData, or the Sequence itself
    // /// <summary>
    // /// Is an empty sequence.
    // /// On run nothing happens.
    // /// No state changes.
    // /// Validation is disabled.
    // /// </summary>
    // public bool IsEmpty { get; set; }

}