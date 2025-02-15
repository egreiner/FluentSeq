namespace FluentSeq;

/// <summary>
/// This is the root element for this library
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class FluentSeq<TState>
{
    /// <summary>
    /// Creates a new sequence builder with wich you can configure the state machine
    /// </summary>
    /// <param name="initialState">The initial state</param>
    /// <returns>A sequence builder</returns>
    public ISequenceBuilder<TState> Create(TState initialState) =>
        new SequenceBuilder<TState>(initialState);

    // public ISequenceBuilder<TState> Configure(TState initialState)
}