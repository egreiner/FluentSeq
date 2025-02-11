namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591

public class State(string name, string description = "")
{
    public string Name { get; } = name;

    public string Description { get; set; } = description;


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