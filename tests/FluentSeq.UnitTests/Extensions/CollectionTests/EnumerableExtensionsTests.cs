namespace FluentSeq.UnitTests.Extensions.CollectionTests;

using System.Collections.Generic;
using FluentSeq.Extensions;

public class EnumerableExtensionsTests
{
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
    public void List_IsNullOrEmpty_ShouldBe_false_when_not_empty()
    {
        var list = new List<int> { 1 };

        var actual = list.IsNullOrEmpty();

        actual.ShouldBeFalse();
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
    public void List_HasItems_ShouldBe_false_when_empty()
    {
        var list = new List<int>();

        var actual = list.HasItems();

        actual.ShouldBeFalse();
    }

    [Fact]
    public void List_HasItems_ShouldBe_true_when_not_empty()
    {
        var list = new List<int> { 1 };

        var actual = list.HasItems();

        actual.ShouldBeTrue();
    }

    [Fact]
    public void List_HasItems_ShouldBe_false_when_null()
    {
        List<int>? list = null;

        var actual = list.HasItems();

        actual.ShouldBeFalse();
    }
}