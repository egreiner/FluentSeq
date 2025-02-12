namespace FluentSeq.UnitTests.LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsExamples1
{
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_variables()
    {
        var number1 = 1;
        var number2 = 2;

        var actual = number1 + number2;

        actual.ShouldBe(3);
    }



    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_method()
    {
        var actual = Add(1, 2);

        actual.ShouldBe(3);
    }

    private int Add(int num1, int num2) =>
        num1 + num2;



    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_local_function1()
    {
        var actual = add(1, 2);

        actual.ShouldBe(3);

        return;

        int add(int num1, int num2) =>
            num1 + num2;
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_local_function2()
    {
        var number1 = 1;
        var number2 = 2;

        var actual = add();

        actual.ShouldBe(3);

        return;

        int add() =>
            number1 + number2;
    }
}