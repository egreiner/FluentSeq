namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

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


    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_old_fashioned_delegate()
    {
        var addDelegate = new PerformCalculation(Add);
        var actual = addDelegate.Invoke(1, 2);

        actual.ShouldBe(3);
    }

    private delegate int PerformCalculation(int x, int y);
    private int Add(int x, int y) => x + y;




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


