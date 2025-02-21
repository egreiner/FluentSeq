namespace FluentSeq.Core;

/// <summary>
/// A collection of items
/// </summary>
/// <typeparam name="T">The item type</typeparam>
public abstract class CollectionBase<T> : List<T>
{
    /// <inheritdoc />
    protected CollectionBase() : base() { }

    /// <inheritdoc />
    protected CollectionBase(IEnumerable<T> enumerable): base(enumerable) { }
}