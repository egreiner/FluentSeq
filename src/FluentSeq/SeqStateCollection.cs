namespace FluentSeq;

using Core;

/// <summary>
/// A collection of sequence states
/// </summary>
/// <typeparam name="TState">The state type</typeparam>
public class SeqStateCollection<TState> : BaseCollection<SeqState<TState>>
{
    /// <inheritdoc />
    public SeqStateCollection(): base() { }

    /// <inheritdoc />
    public SeqStateCollection(IEnumerable<SeqState<TState>> enumerable) : base(enumerable) { }


    /// <summary>
    /// Returns the sequence-state by the state value
    /// </summary>
    /// <param name="theState">The state value</param>
    public SeqState<TState>? GetSeqState(TState theState) =>
        this.FirstOrDefault(x => x?.State?.Equals(theState) ?? false);
}