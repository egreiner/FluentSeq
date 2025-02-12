namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsExamples4
{
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_LINQ()
    {
        var numberArray = new [] { 1, 2 };

        var actual = numberArray.Sum();

        actual.ShouldBe(3);
    }
}


