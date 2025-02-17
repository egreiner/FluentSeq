namespace FluentSeq.UnitTests.LearningTests.Dojo.FizzBuzz;

using System.Collections.Concurrent;

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
        var actual = value.ToFizzBuzz();

        actual.ShouldBe((value, "Fizz"));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(25)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(40)]
    public void ToFizzBuzz_ShouldReturn_Buzz(int value)
    {
        var actual = value.ToFizzBuzz();

        actual.ShouldBe((value, "Buzz"));
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public void ToFizzBuzz_ShouldReturn_FizzBuzz(int value)
    {
        var actual = value.ToFizzBuzz();

        actual.ShouldBe((value, "FizzBuzz"));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    public void ToFizzBuzz_ShouldReturn_NumberAsString(int value)
    {
        var actual = value.ToFizzBuzz();

        actual.ShouldBe((value, value.ToString()));
    }


    [Fact]
    public void ToFizzBuzz_ShouldReturn_String()
    {
        var max = 100000;
        var values = Enumerable.Range(1, max).ToList();
        var actual = new List<(int, string)>();

        values.ForEach(value => actual.Add(value.ToFizzBuzz()));

        actual.Count.ShouldBe(max);
    }
}