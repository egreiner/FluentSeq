namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// This is the root element for this library
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class FluentSeq<TState>
{
    public ISequenceBuilder<TState> Create(TState initialState) =>
        new SequenceBuilder<TState>(initialState);
}