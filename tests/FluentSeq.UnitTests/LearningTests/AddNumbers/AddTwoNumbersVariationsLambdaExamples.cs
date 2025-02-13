namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsLambdaExamples
{
    /// <summary>
    /// Two numbers are added
    /// Context:
    /// A function is declared that adds two numbers.
    /// The function can be handed over to other functions.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_lambda_expression1()
    {
        Func<int> addFct = () => 1 + 2;
        var actual = addFct.Invoke();

        actual.ShouldBe(3);
    }

    /// <summary>
    /// Two numbers are added
    /// Context:
    /// A function with variable inputs is declared that adds two numbers.
    /// The function can be handed over to other functions.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_lambda_expression2()
    {
        var addFct = (int n1, int n2) => n1 + n2;
        var actual = addFct.Invoke(1, 2);
        // or var actual = addFct(1, 2);

        actual.ShouldBe(3);
    }


    /// <summary>
    /// Two numbers are added
    /// Context:
    /// This is the old way of making it possible to hand over functions.
    /// A delegate is declared that describes a function signature.
    /// The delegate can be handed over to other functions.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_old_fashioned_delegate()
    {
        var addDelegate = new PerformCalculation(Add);
        var actual = addDelegate.Invoke(1, 2);

        actual.ShouldBe(3);
    }


    /// <summary>
    /// Two numbers are multiplied
    /// Context:
    /// This is the old way of making it possible to hand over functions.
    /// The same delegate can handle another function, the important thing is, the signatures must match.
    /// The delegate can be handed over to other functions.
    /// </summary>
    [Fact]
    public void MultiplyTwoNumbers_ShouldReturn_TheResult_use_old_fashioned_delegate()
    {
        var addDelegate = new PerformCalculation(Multiply);
        var actual = addDelegate.Invoke(1, 2);

        actual.ShouldBe(2);
    }

    private delegate int PerformCalculation(int x, int y);
    private int Add(int x, int y) => x + y;
    private int Multiply(int x, int y) => x * y;




    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_lambda_expression3()
    {
        Func<int, int, int> addFct = (x, y) => Add(x, y);
        var actual = addFct.Invoke(1, 2);
        // or var actual = addFct(1, 2);

        actual.ShouldBe(3);
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_lambda_expression4()
    {
        Func<int, int, int> addFct = Add;
        var actual = addFct.Invoke(1, 2);
        // or var actual = addFct(1, 2);

        actual.ShouldBe(3);
    }
}