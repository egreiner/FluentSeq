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

    IStateBuilder<TState> State(TState state);

    ISequenceBuilder<TState> Builder();

    // TODO public ISequence<TState> Build()
}