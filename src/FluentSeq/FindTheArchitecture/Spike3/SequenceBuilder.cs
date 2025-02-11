namespace FluentSeq.FindTheArchitecture.Spike3;

/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    /// <summary>
    /// Creates a new instance of <see cref="SequenceBuilder{TState}"/>
    /// with a specified initial state
    /// </summary>
    /// <param name="initialState">The initial state of the sequence</param>
    // TODO maybe injecting a complete SequenceConfiguration here would be better, that makes everything more open
    public SequenceBuilder(TState initialState)
    {
        InitialState = initialState;
        RootSequenceBuilder = this;
    }

    /// <inheritdoc />
    public TState InitialState { get; }

    /// <summary>
    /// The root SequenceBuilder
    /// </summary>
    protected ISequenceBuilder<TState> RootSequenceBuilder { get; set; }


    /// <inheritdoc />
    public IStateBuilder<TState> ConfigureState(TState state, string description = "") =>
        new StateBuilder<TState>(Builder(), state?.ToString() ?? string.Empty, description);

    /// <inheritdoc />
    public ISequenceBuilder<TState> Builder() =>
        RootSequenceBuilder;
}