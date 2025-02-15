namespace FluentSeq.Extensions;

/// <summary>
/// ExtensionMethods for <see cref="IList{T}"/>
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Add a range of items to the list.
    /// Does not raise an exception if the list/items is null.
    /// </summary>
    /// <param name="list">The original list</param>
    /// <param name="items">The items that should be added</param>
    public static void AddRange<T>(this IList<T>? list, IEnumerable<T>? items)
    {
        if (list == null) return;
        if (items == null) return;

        if (list is List<T> asList)
        {
            asList.AddRange(items);
            return;
        }

        foreach (var item in items)
        {
            list.Add(item);
        }
    }
}