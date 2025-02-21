namespace FluentSeq.UnitTests.Extensions.CollectionTests;

using System.Collections.Generic;
using System.Linq;
using FluentSeq.Extensions;

public class UniqueExtensionsTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(1, 2)]
    [InlineData(1, 2, 3)]
    public void Test_is_same(params int[] values)
    {
        var expected = values.ToArray();

        var actual = expected.Unique();

        actual.Count.ShouldBe(expected.Length);
        actual.ShouldBeUnique();
    }


    [Theory]
    [MemberData(nameof(GetIntData), 2)]
    public void Test_Unique_int(int[] values, int[] expected)
    {
        var actual = values.Unique();

        actual.Count.ShouldBe(expected.Length);
        actual.ShouldBeUnique();
    }

    public static IEnumerable<object[]> GetIntData(int numTests)
    {
        yield return [new[] { 1, 2, 3 }, new[] { 1, 2, 3 }];
        yield return [new[] { 1, 2, 3, 3, 1 }, new[] { 1, 2, 3 }];
        yield return [new[] { 3, 2, 3, 3, 1 }, new[] { 3, 2, 1 }];
    }


    [Theory]
    [MemberData(nameof(GetStringData), 2)]
    public void Test_Unique_string(string[] values, string[] expected)
    {
        var actual = values.Unique();

        actual.Count.ShouldBe(expected.Length);
        actual.ShouldBeUnique();
    }

    public static IEnumerable<object[]> GetStringData(int numTests)
    {
        yield return [new[] { "1", "2", "3" }, new[] { "1", "2", "3" }];
        yield return [new[] { "1", "2", "3", "2", "3" }, new[] { "1", "2", "3" }];
        yield return [new[] { "3", "2", "3", "2", "1" }, new[] { "3", "2", "1" }];
        ////yield return new object[] { new[] { 1, 2, 3, 3, 1 }, new[] { 1, 2, 3 } };
        ////yield return new object[] { new[] { 3, 2, 3, 3, 1 }, new[] { 3, 2, 1 } };
    }
}