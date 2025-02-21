namespace FluentSeq.UnitTests.Extensions.CollectionTests;

using System.Collections;
using System.Collections.Generic;
using FluentSeq.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public void ToClonedList_ShouldBe_as_original()
    {
        var list = new List<string> { "Test1", "Test2" };

        var actual = list.ToClonedList();

        actual.ShouldContain("Test1");
        actual.ShouldContain("Test2");
        actual.ShouldNotContain("Test3");
    }

    [Fact]
    public void IEnumerable_IsNullOrEmpty_ShouldBe_true_when_null()
    {
        IEnumerable<int>? collection = null;

        bool actual = collection.IsNullOrEmpty();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void IEnumerable_IsNullOrEmpty_ShouldBe_true_when_empty()
    {
        IEnumerable<int> collection = new List<int>();

        bool actual = collection.IsNullOrEmpty();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void IEnumerable_HasItems_ShouldBe_false_when_null()
    {
        IEnumerable<int>? collection = null;

        bool actual = collection.HasItems();

        actual.ShouldBeFalse();
    }

    [Fact]
    public void IEnumerable_HasItems_ShouldBe_false_when_empty()
    {
        IEnumerable<int> collection = new List<int>();

        bool actual = collection.HasItems();

        actual.ShouldBeFalse();
    }

    [Fact]
    public void IEnumerable_HasItems_ShouldBe_true()
    {
        IEnumerable<int> collection = new List<int> { 1 };

        bool actual = collection.HasItems();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void Array_HasItems_ShouldBe_false_when_null()
    {
        ArrayList? array = null;

        bool actual = array.HasItems();

        actual.ShouldBeFalse();
    }

    [Fact]
    public void Array_HasItems_ShouldBe_true()
    {
        var array = new ArrayList(2) { "Test" };

        array.HasItems().ShouldBeTrue();
    }

    [Fact]
    public void Array_HasItems_ShouldBe_false()
    {
        var array = new ArrayList(2);

        array.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void List_HasItems_ShouldBe_false_when_empty()
    {
        var list = new List<int>();

        list.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void List_HasItems_ShouldBe_true_when_not_empty()
    {
        var array = new List<int> { 1 };

        array.HasItems().ShouldBeTrue();
    }

    [Fact]
    public void List_HasItems_ShouldBe_false_when_null()
    {
        List<int>? list = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        list.HasItems().ShouldBeFalse();
    }

    [Fact]
    public void Array_IsNullOrEmpty_ShouldBe_false_when_not_empty()
    {
        var array = new ArrayList(2) { "Test" };

        array.IsNullOrEmpty().ShouldBeFalse();
    }

    [Fact]
    public void Array_IsNullOrEmpty_ShouldBe_true_when_empty()
    {
        var array = new ArrayList(2);

        array.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void Array_IsNullOrEmpty_ShouldBe_true_when_null()
    {
        ArrayList? array = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        array.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void List_IsNullOrEmpty_ShouldBe_true_when_empty()
    {
        var list = new List<int>();

        list.IsNullOrEmpty().ShouldBeTrue();
    }

    [Fact]
    public void List_IsNullOrEmpty_ShouldBe_false_when_not_empty()
    {
        var array = new List<int> { 1 };

        array.IsNullOrEmpty().ShouldBeFalse();
    }

    [Fact]
    public void List_IsNullOrEmpty_ShouldBe_true_when_null()
    {
        List<int>? list = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        list.IsNullOrEmpty().ShouldBeTrue();
    }
}