namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsExtensionMethodExamples
{
    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers are added, but it's not done here, it's done in a ExtensionMethod.
    /// This method can be called also from other places, and it can be chained.(.Add().Add().Add()... )
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_ExtensionMethod()
    {
        var actual = 1.Add(2);

        actual.ShouldBe(3);
    }
}


public static class MathExtensions
{
    public static int Add(this int num1, int num2) =>
        num1 + num2;
}