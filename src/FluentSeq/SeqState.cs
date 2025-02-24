namespace FluentSeq;

/// <summary>
/// Describes a state
/// </summary>
public class SeqState<TState>
{
    /// <summary>
    /// Describes a state
    /// </summary>
    /// <param name="state">The state</param>
    /// <param name="description">The description of the state</param>
    public SeqState(TState state, string description = "")
    {
        State = state;
        Name = state?.ToString() ?? Guid.NewGuid().ToString();
        Description = description;
    }

    /// <summary>
    /// The state
    /// </summary>
    public TState State { get; }

    /// <summary>
    /// The name of the state
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The description of the state
    /// </summary>
    public string Description { get; }


    /// <summary>
    /// Gets a list of trigger for this state
    /// </summary>
    public List<Trigger<TState>> Trigger { get; } = new();

    /// <summary>
    /// The actions to perform when entering the state
    /// </summary>
    public List<Action> EntryActions { get; } = new();

    /// <summary>
    /// The actions to perform when exiting the state
    /// </summary>
    public List<Action> ExitActions { get; } = new();


    /// <inheritdoc />
    public override string ToString() =>
        $"{Name} {Description} | has action(s): {EntryActions.Count > 0}";

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is SeqState<TState> state && Name.Equals(state.Name);

    /// <inheritdoc />
    public override int GetHashCode() =>
        Name.GetHashCode();
}