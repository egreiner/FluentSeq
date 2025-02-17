namespace FluentSeq.UnitTests.LearningTests.Dojo.FizzBuzz;


// FizzBuzz rules
// 1. If the number is divisible by 3, print Fizz
// 2. If the number is divisible by 5, print Buzz
// 3. If the number is divisible by 3 and 5, print FizzBuzz

public class FizzBuzzTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public void ToFizzBuzz_ShouldReturn_Fizz(int value)
    {
        var actual = ToFizzBuzz(value);

        actual.ShouldBe("Fizz");
    }

    [Theory]
    [InlineData(5)]
    [InlineData(25)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(40)]
    public void ToFizzBuzz_ShouldReturn_Buzz(int value)
    {
        var actual = ToFizzBuzz(value);

        actual.ShouldBe("Buzz");
    }




    private static string ToFizzBuzz(int value)
    {
        if (value % 3 == 0)
        {
            return "Fizz";
        }

        if (value % 5 == 0)
        {
            return "Buzz";
        }

        return value.ToString();
    }
}