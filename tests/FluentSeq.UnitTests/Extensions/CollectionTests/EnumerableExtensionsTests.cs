namespace FluentSeq.UnitTests.Extensions.CollectionTests;

using System.Collections;
using System.Collections.Generic;
using FluentSeq.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public void Test_ToClonedList()
    {
        var list = new List<string> { "Test1", "Test2" };

        var actual = list.ToClonedList();

        actual.ShouldContain("Test1");
        actual.ShouldContain("Test2");
        actual.ShouldNotContain("Test3");
    }

    [Fact]
    public void Test_IsNull()
    {
        IEnumerable<int> collection = null;

        bool actual = collection.IsNullOrEmpty();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void Test_IsEmpty()
    {
        IEnumerable<int> collection = new List<int>();

        bool actual = collection.IsNullOrEmpty();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void Test_Null_HasItems()
    {
        IEnumerable<int> collection = null;

        bool actual = collection.HasItems();

        actual.ShouldBeFalse();
    }

    [Fact]
    public void Test_Empty_HasItems()
    {
        IEnumerable<int> collection = new List<int>();

        bool actual = collection.HasItems();

        actual.ShouldBeFalse();
    }

    [Fact]
    public void Test_One_HasItems()
    {
        IEnumerable<int> collection = new List<int> { 1 };

        bool actual = collection.HasItems();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void HasItems_CanHandleNullValues_Test01()
    {
        ArrayList array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void HasItems_Test01()
    {
        var array = new ArrayList(2) { "Test" };

        array.HasItems().ShouldBeTrue();
    }

    [Fact]
    public void HasItems_Test02()
    {
        var array = new ArrayList(2);

        array.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void HasItems_Test05()
    {
        var array = new List<int>();

        array.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void HasItems_Test06()
    {
        var array = new List<int> { 1 };

        array.HasItems().ShouldBeTrue();
    }

    [Fact]
    public void HasItems_Test07()
    {
        List<int> array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void HasItems_Test08()
    {
        var array = new List<int> { 1 };
        array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_Test01()
    {
        var array = new ArrayList(2) { "Test" };

        array.IsNullOrEmpty().ShouldBeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_Test02()
    {
        var array = new ArrayList(2);

        array.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Test03()
    {
        ArrayList array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Test05()
    {
        var array = new List<int>();

        array.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Test06()
    {
        var array = new List<int> { 1 };

        array.IsNullOrEmpty().ShouldBeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_Test07()
    {
        var array = new List<int>();
        array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Test08()
    {
        var array = new List<int> { 1 };
        array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.IsNullOrEmpty().ShouldBeTrue();
    }
}