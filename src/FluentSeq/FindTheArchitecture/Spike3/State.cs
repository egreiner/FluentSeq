namespace FluentSeq.FindTheArchitecture.Spike3;

// TODO make this generic?
/// <summary>
/// Describes a state
/// </summary>
/// <param name="name">The name of the state</param>
/// <param name="description">The description of the state</param>
public class State(string name, string description = "")
{
    /// <summary>
    /// The name of the state
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// The description of the state
    /// </summary>
    public string Description { get; } = description;


    /// <inheritdoc />
    public override string ToString() =>
        $"{Name} {Description}";

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj is State state && Name.Equals(state.Name);

    /// <inheritdoc />
    public override int GetHashCode() =>
        Name.GetHashCode();
}