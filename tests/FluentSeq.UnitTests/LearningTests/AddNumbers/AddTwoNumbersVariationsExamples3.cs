namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

using System.Linq.Expressions;

public sealed class AddTwoNumbersVariationsExamples3
{
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_lambda_expression1()
    {
        var addFct = () => 1 + 2;
        var actual = addFct.Invoke();

        actual.ShouldBe(3);
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_lambda_expression2()
    {
        var addFct = (int n1, int n2) => n1 + n2;
        var actual = addFct.Invoke(1, 2);
        // or var actual = addFct(1, 2);

        actual.ShouldBe(3);
    }
}


