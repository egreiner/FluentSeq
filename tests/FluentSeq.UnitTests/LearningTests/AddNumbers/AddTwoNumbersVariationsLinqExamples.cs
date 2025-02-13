namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsLinqExamples
{
    /// <summary>
    /// Two or more numbers are added
    /// Context:
    /// Two or more numbers are added, but it's not done here,
    /// it's done by another library (LINQ).
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_LINQ()
    {
        var numberArray = new [] { 1, 2 };

        var actual = numberArray.Sum();

        actual.ShouldBe(3);
    }
}


