namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbers
{
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum()
    {
        var actual = 1 + 2;

        actual.ShouldBe(3);
    }
}