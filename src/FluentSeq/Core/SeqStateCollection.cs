namespace FluentSeq.Core;

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
}