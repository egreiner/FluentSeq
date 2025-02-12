namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

using System.Linq.Expressions;

public sealed class AddTwoNumbersVariationsExamples5
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


    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_LINQ()
    {
        var numberArray = new [] { 1, 2 };

        var actual = numberArray.Sum();

        actual.ShouldBe(3);
    }



    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_expression_trees1()
    {
        var expression = Expression.Lambda<Func<int>>(Expression.Add(Expression.Constant(1), Expression.Constant(2)));
        var compiledExpression = expression.Compile();

        var actual = compiledExpression();

        actual.ShouldBe(3);
    }


    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_expression_trees2()
    {
        Func<int> addFct = () => 1 + 2;
        var addFctExpression = Expression.Invoke(Expression.Constant(addFct));
        var compiledExpression = Expression.Lambda<Func<int>>(addFctExpression).Compile();

        var actual = compiledExpression();

        actual.ShouldBe(3);
    }
}


