namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public class AddTwoNumbers
{
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum()
    {
        var number1 = 1;
        var number2 = 2;

        var actual = number1 + number2;

        actual.ShouldBe(3);
    }
}