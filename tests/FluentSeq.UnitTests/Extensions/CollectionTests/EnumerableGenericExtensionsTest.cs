namespace FluentSeq.UnitTests.Extensions.CollectionTests;

using System.Collections;
using System.Collections.Generic;
using FluentSeq.Extensions;

public class EnumerableGenericExtensionsTest
{
    [Fact]
    public void HasItems_Generic_empty()
    {
        var actual = new List<string>().HasItems();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void HasItems_Generic_null()
    {
        List<string>? genericList = null;

        var actual = genericList.HasItems();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void HasItems_Generic_string()
    {
        var genericList = new List<string> { "1", "2" };

        var actual = genericList.HasItems();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void HasItems_Generic_int()
    {
        var genericList = new List<int> { 10, 20 };

        var actual = genericList.HasItems();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void HasItems_empty()
    {
        var actual = new ArrayList().HasItems();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void HasItems_null()
    {
        var actual = ((IEnumerable)null).HasItems();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void HasItems_string()
    {
        var arrayList = new ArrayList { "1", "2" };

        var actual = arrayList.HasItems();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void HasItems_int()
    {
        var arrayList = new ArrayList { 3, 4 };

        var actual = arrayList.HasItems();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Generic_empty()
    {
        var actual = new List<string>().IsNullOrEmpty();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Generic_null()
    {
        List<string>? genericList = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        var actual = genericList.IsNullOrEmpty();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_Generic_string()
    {
        var genericList = new List<string> { "1", "2" };

        var actual = genericList.IsNullOrEmpty();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_Generic_int()
    {
        var genericList = new List<int> { 10, 20 };

        var actual = genericList.IsNullOrEmpty();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_empty()
    {
        var actual = new ArrayList().IsNullOrEmpty();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_null()
    {
        var actual = ((IEnumerable)null).IsNullOrEmpty();
        actual.ShouldBeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_string()
    {
        var arrayList = new ArrayList { "1", "2" };

        var actual = arrayList.IsNullOrEmpty();
        actual.ShouldBeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_int()
    {
        var arrayList = new ArrayList { 3, 4 };

        var actual = arrayList.IsNullOrEmpty();
        actual.ShouldBeFalse();
    }
}