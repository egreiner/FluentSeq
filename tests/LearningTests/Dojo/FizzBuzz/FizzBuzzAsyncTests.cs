namespace LearningTests.Dojo.FizzBuzz;

using System.Collections.Concurrent;

// FizzBuzz rules
// 1. If the number is divisible by 3, print Fizz
// 2. If the number is divisible by 5, print Buzz
// 3. If the number is divisible by 3 and 5, print FizzBuzz


public class FizzBuzzAsyncTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public async Task ToFizzBuzzAsync_ShouldReturn_Fizz(int value)
    {
        var actual = await value.ToFizzBuzzAsync().ConfigureAwait(true);

        actual.ShouldBe((value, "Fizz"));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(25)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(40)]
    public async Task ToFizzBuzzAsync_ShouldReturn_Buzz(int value)
    {
        var actual = await value.ToFizzBuzzAsync().ConfigureAwait(true);
    
        actual.ShouldBe((value, "Buzz"));
    }
    
    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public async Task ToFizzBuzzAsync_ShouldReturn_FizzBuzz(int value)
    {
        var actual = await value.ToFizzBuzzAsync().ConfigureAwait(true);
    
        actual.ShouldBe((value, "FizzBuzz"));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    public async Task ToFizzBuzzAsync_ShouldReturn_NumberAsString(int value)
    {
        var actual = await value.ToFizzBuzzAsync().ConfigureAwait(true);
    
        actual.ShouldBe((value, value.ToString()));
    }

    [Fact]
    public async Task ToFizzBuzzAsync_ShouldReturn_String()
    {
        var max = 100000;
        var values = Enumerable.Range(1, max);
        var tasks = new ConcurrentBag<Task<(int, string)>>();

        Parallel.ForEach(values, value =>
        {
            tasks.Add(value.ToFizzBuzzAsync());
        });

        var actual = await Task.WhenAll(tasks);

        actual.Length.ShouldBe(max);
    }
}