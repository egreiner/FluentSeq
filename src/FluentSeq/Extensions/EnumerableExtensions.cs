namespace FluentSeq.Extensions;

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

/// <summary>
/// Extensions for the enumerable
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Returns TRUE if the enumerable has items.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    /// <typeparam name="T">The type of the enumerable</typeparam>
    public static bool HasItems<T>(this IEnumerable<T>? enumerable) => !IsNullOrEmpty(enumerable);

    /// <summary>
    /// Returns TRUE if ALL the items complies to the predicate.
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [AssertionMethod]
    public static bool IsNullOrEmpty<T>(
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this IEnumerable<T>? enumerable)
    {
        if (enumerable == null)
            return true;

        if (enumerable is ICollection<T> collection)
            return collection.Count == 0;

        using var enumerator = enumerable.GetEnumerator();
        return !enumerator.MoveNext();
    }
}