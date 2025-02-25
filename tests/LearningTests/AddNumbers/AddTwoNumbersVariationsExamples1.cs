namespace LearningTests.AddNumbers;

public sealed class AddTwoNumbersVariationsExamples1
{
    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers with special meaning are declared, later on, they are added
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_variables()
    {
        var number1 = 1;
        var number2 = 2;

        var actual = number1 + number2;

        actual.ShouldBe(3);
    }



    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers are added, but it's not done here, it's done in a method.
    /// This method can be called also from other places.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_method()
    {
        var actual = Add(1, 2);

        actual.ShouldBe(3);
    }

    private int Add(int num1, int num2) =>
        num1 + num2;



    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers are added, but it's not done here, it's done in a local function.
    /// This method can only be called in this method.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum_use_local_function1()
    {
        var actual = add(1, 2);

        actual.ShouldBe(3);

        return;

        int add(int num1, int num2) =>
            num1 + num2;
    }

    /// <summary>
    /// Two numbers are added
    /// Context:
    /// The same as before, but with other syntax
    /// </summary>
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