namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddMoreNumbersVariationsExamples1
{
    [Fact]
    public void AddMoreNumbers_ShouldReturn_TheSum_use_method1()
    {
        var actual = Add(1, 2);

        actual.ShouldBe(3);
    }


    [Fact]
    public void AddMoreNumbers_ShouldReturn_TheSum_use_method2()
    {
        var actual = Add(1, 2, 4);

        actual.ShouldBe(7);
    }

    [Fact]
    public void AddMoreNumbers_ShouldReturn_TheSum_use_method3()
    {
        var actual = Add(1);

        actual.ShouldBe(1);
    }



    private int Add(int num1, params int[] nums)
    {
        var result = num1;

        foreach (var num in nums)
        {
            result += num;
        }

        return result;
    }
}