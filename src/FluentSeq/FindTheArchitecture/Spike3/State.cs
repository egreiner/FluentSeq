namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
public class State(string name)
{
    public string Name { get; set; } = name;

    public string Description { get; set; } = string.Empty;
}