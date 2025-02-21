namespace FluentSeq.UnitTests.Extensions.CollectionTests;

using FluentSeq.Extensions;

public class EnumerableExtensionsToJoinedStringTests
{
    [Fact]
    public void Test_JoinToString_ListOfStrings()
    {
        var list = new List<string> { "Test1", "Test2" };

        var actual = list.ToJoinedString();

        var expected = "Test1, Test2";
        actual.ShouldBe(expected);
    }

    [Fact]
    public void Test_JoinToString_ListOfInt()
    {
        var list = new List<int> { 1, 2, 3 };

        var actual = list.ToJoinedString();

        var expected = "1, 2, 3";
        actual.ShouldBe(expected);
    }

    [Fact]
    public void Test_JoinToString_ArrayOfStrings()
    {
        string[] list = new List<string> { "Test1", "Test2" }.ToArray();

        var actual = list.ToJoinedString();

        var expected = "Test1, Test2";
        actual.ShouldBe(expected);
    }

    [Fact]
    public void Test_JoinToString_ArrayOfInt()
    {
        int[] list = new List<int> { 1, 2, 3 }.ToArray();

        var actual = list.ToJoinedString();

        var expected = "1, 2, 3";
        actual.ShouldBe(expected);
    }
}