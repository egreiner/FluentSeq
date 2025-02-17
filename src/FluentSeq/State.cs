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


    /// <inheritdoc />
    public override string ToString() =>
        $"{Name} {Description}";

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is SeqState<TState> state && Name.Equals(state.Name);

    /// <inheritdoc />
    public override int GetHashCode() =>
        Name.GetHashCode();
}