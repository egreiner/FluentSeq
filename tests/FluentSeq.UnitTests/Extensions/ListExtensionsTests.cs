namespace FluentSeq.UnitTests.Extensions;

using FluentSeq.Extensions;

public class ListExtensionsTests
{
    [Fact]
    public void AddRange_ShouldAddItemsToList()
    {
        IList<int> list = new List<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        list.AddRange(itemsToAdd);

        list.Count.ShouldBe(6);
        list.ShouldContain(4);
        list.ShouldContain(5);
        list.ShouldContain(6);
    }

    [Fact]
    public void AddRange_WithNullList_ShouldReturn_null()
    {
        // TODO or should it return the items as list?
        IList<int>? list = null;
        var itemsToAdd = new List<int> { 4, 5, 6 };

        list.AddRange(itemsToAdd);

        list.ShouldBeNull();
    }


    [Fact]
    public void AddRange_WithNullItems_ShouldReturn_List()
    {
        IList<int> list = new List<int> { 1, 2, 3 };
        IEnumerable<int>? itemsToAdd = null;

        list.AddRange(itemsToAdd);

        list.Count.ShouldBe(3);
        list.ShouldContain(1);
        list.ShouldContain(2);
        list.ShouldContain(3);
    }


    // TODO add tests!
    // add test for AddRange with null items
    // add test for AddRange with List<T>
    // add test for AddRange with IEnumerable<T>
    // add test for AddRange with null list and null items
    // add test for AddRange with null list and List<T>
    // add test for AddRange with null list and IEnumerable<T>
    // add test for AddRange with List<T> and null items
    // add test for AddRange with IEnumerable<T> and null items
    // add test for AddRange with List<T> and List<T>
    // add test for AddRange with List<T> and IEnumerable<T>
    // add test for AddRange with IEnumerable<T> and List<T>
    // add test for AddRange with IEnumerable<T> and IEnumerable<T>
    // add test for AddRange with List<T> and List<T> with null items
    // add test for AddRange with List<T> and IEnumerable<T> with null items
    // add test for AddRange with IEnumerable<T> and List<T> with null items
    // add test for AddRange with IEnumerable<T> and IEnumerable<T> with null items
}