namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591

public class State(string name, string description = "")
{
    public string Name { get; set; } = name;

    public string Description { get; set; } = description;
}
