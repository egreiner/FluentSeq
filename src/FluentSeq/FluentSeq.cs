namespace FluentSeq;

using Builder;

/// <summary>
/// This is the root element for FluentSeq
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class FluentSeq<TState>
{
    /// <summary>
    /// Initializes a new sequence builder with the specified initial state.
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    /// <returns>A sequence builder to configure the state machine</returns>
    public ISequenceBuilder<TState> Create(TState initialState) =>
        new SequenceBuilder<TState>(initialState);


    /// <summary>
    /// Configures a sequence with detailed settings using the provided actions.
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    /// <param name="configurationActions">The actions to configure the sequence</param>
    /// <returns>A sequence builder with the applied configurations</returns>
    public ISequenceBuilder<TState> Configure(TState initialState, Action<ISequenceBuilder<TState>> configurationActions)
    {
        var sequenceBuilder = Create(initialState);
        configurationActions.Invoke(sequenceBuilder);
        return sequenceBuilder;
    }
}