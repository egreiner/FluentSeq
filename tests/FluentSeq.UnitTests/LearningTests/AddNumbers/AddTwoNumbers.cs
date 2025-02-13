namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbers
{
    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers are added, the simplest way possible.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum()
    {
        var actual = 1 + 2;

        actual.ShouldBe(3);
    }
}