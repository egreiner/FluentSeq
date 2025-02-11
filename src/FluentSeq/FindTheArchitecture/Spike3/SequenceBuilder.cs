namespace FluentSeq.FindTheArchitecture.Spike3;

/// <summary>
/// Provides methods for configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    /// <summary>
    /// Creates a new instance of <see cref="SequenceBuilder{TState}"/>
    /// with a specified initial state
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    public SequenceBuilder(TState initialState)
    {
        InitialState = initialState;
        RootSequenceBuilder = this;
    }

    /// <summary>
    /// The initial state of the sequence
    /// </summary>
    public TState InitialState { get; }

    /// <summary>
    /// The root SequenceBuilder
    /// </summary>
    protected ISequenceBuilder<TState> RootSequenceBuilder { get; set; }


    /// <summary>
    /// Creates a new State
    /// </summary>
    /// <param name="state">The name of the state</param>
    /// <returns>A StateBuilder</returns>
    public IStateBuilder<TState> State(TState state) => new StateBuilder<TState>(Builder());

    /// <summary>
    /// Returns the root SequenceBuilder
    /// </summary>
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;
}