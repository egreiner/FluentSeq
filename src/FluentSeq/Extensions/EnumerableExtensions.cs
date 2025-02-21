namespace FluentSeq.Extensions;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

/// <summary>
/// Extensions for the enumerable
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Clones the specified source
    /// </summary>
    /// <typeparam name="T">The Type</typeparam>
    /// <param name="source">The list source</param>
    public static List<T> ToClonedList<T>(this IEnumerable<T> source) => new(source);


    /// <summary>
    /// Returns a joined enumeration as string.
    /// </summary>
    /// <typeparam name="T">The Type.</typeparam>
    /// <param name="source">The list source.</param>
    /// <param name="separator"></param>
    public static string ToJoinedString<T>(this IEnumerable<T>? source, string separator = ", ") =>
        source == null ? string.Empty : string.Join(separator, source);


    /// <summary>
    /// Returns the list, if the list is null return an empty list of specified type
    /// </summary>
    /// <typeparam name="T">The Type.</typeparam>
    /// <param name="source">The list source.</param>
    public static List<T> ToNotNullList<T>(this IEnumerable<T>? source) =>
        source?.ToList() ?? new List<T>();

    /// <summary>
    /// Returns TRUE if the enumerable has items.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    /// <typeparam name="T">The type of the enumerable</typeparam>
    public static bool HasItems<T>(this IEnumerable<T> enumerable) => !IsNullOrEmpty(enumerable);

    /// <summary>
    /// Returns TRUE if the enumerable has items.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    public static bool HasItems(this IEnumerable enumerable) => !IsNullOrEmpty(enumerable);

    /// <summary>
    /// Returns TRUE if NONE of the items complies to the predicate.
    /// </summary>
    /// <typeparam name="T">The Type.</typeparam>
    /// <param name="source">The list source.</param>
    /// <param name="predicate">The predicate</param>
    public static bool None<T>(this IEnumerable<T>? source, Func<T, bool> predicate) =>
        !source?.Any(predicate) ?? true;

    /// <summary>
    /// Returns TRUE if ALL the items complies to the predicate.
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [AssertionMethod]
    public static bool IsNullOrEmpty<T>(
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this IEnumerable<T>? enumerable) =>
        enumerable?.Any() != true;

    /// <summary>
    /// Returns TRUE if the enumerable is null or has no items.
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    [AssertionMethod]
    public static bool IsNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this IEnumerable? enumerable) =>
        enumerable == null || !enumerable.GetEnumerator().MoveNext();


    /// <summary>
    /// Returns an unique enumeration.
    /// </summary>
    /// <param name="values"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static HashSet<T> Unique<T>(this IEnumerable<T> values) =>
        new(values);
}