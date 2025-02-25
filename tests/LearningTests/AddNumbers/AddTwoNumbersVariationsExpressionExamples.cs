namespace LearningTests.AddNumbers;

using System.Linq.Expressions;

public sealed class AddTwoNumbersVariationsExpressionExamples
{
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_expression_trees1()
    {
        Func<int> addFct = () => 1 + 2;
        var addFctExpression = Expression.Invoke(Expression.Constant(addFct));
        var compiledExpression = Expression.Lambda<Func<int>>(addFctExpression).Compile();

        var actual = compiledExpression.Invoke();

        actual.ShouldBe(3);
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_expression_trees2()
    {
        var expression = Expression.Lambda<Func<int>>(
            Expression.Add(Expression.Constant(1), Expression.Constant(2)));

        var compiledExpression = expression.Compile();

        var actual = compiledExpression.Invoke();

        actual.ShouldBe(3);
    }
}
