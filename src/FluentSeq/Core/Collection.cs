namespace FluentSeq.Core;

/// <summary>
/// A collection of items
/// </summary>
/// <typeparam name="T">The item type</typeparam>
public abstract class BaseCollection<T> : List<T>
{
    /// <inheritdoc />
    protected BaseCollection() : base() { }

    /// <inheritdoc />
    protected BaseCollection(IEnumerable<T> enumerable): base(enumerable) { }
}