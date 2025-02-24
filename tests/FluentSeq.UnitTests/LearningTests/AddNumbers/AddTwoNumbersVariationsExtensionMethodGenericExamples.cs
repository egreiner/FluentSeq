namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsExtensionMethodGenericExamples
{
    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers are added, but it's not done here, it's done in a ExtensionMethod.
    /// This method can be called also from other places, and it can be chained.(.Add().Add().Add()... )
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_GenericExtensionMethod()
    {
        var actual = 1.1.AddGeneric(2.3);

        actual.ShouldBe(3.4);
    }
}


public static class MathGenericExtensions
{
    public static T AddGeneric<T>(this T num1, T num2)
        where T: System.Numerics.IAdditionOperators<T, T, T> =>
        num1 + num2;
}