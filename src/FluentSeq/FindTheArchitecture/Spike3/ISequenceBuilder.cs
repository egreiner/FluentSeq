namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ISequenceBuilder<TState>
{

    // TODO public ISequence<TState> Build()

    internal HashSet<StateBuilder<TState>> StateBuilders { get; }

    /// <summary>
    /// Returns a list of all registered states
    /// </summary>
    IList<State> RegisteredStates { get; }

    /// <summary>
    /// The options for building a sequence
    /// </summary>
    SequenceOptions<TState> Options { get; }


    // TODO rename to AddState???
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


    /// <summary>
    /// The complete validation of the sequence configuration will be disabled
    /// </summary>
    ISequenceBuilder<TState> DisableValidation();

    /// <summary>
    /// The validation for the specified states within the sequence configuration will be disabled
    /// </summary>
    ISequenceBuilder<TState> DisableValidationForStates(params TState[] states);
}