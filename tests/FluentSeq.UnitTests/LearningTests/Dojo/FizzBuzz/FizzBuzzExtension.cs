namespace FluentSeq.UnitTests.LearningTests.Dojo.FizzBuzz;

public static class FizzBuzzExtension
{
    /// <summary>
    /// Return the fizz-buzzed value
    /// </summary>
    /// <param name="value">An integer value</param>
    public static (int, string) ToFizzBuzz(this int value) =>
        value switch
        {
            var x when x % 15 == 0 => (x, "FizzBuzz"),
            var x when x % 3 == 0 => (x, "Fizz"),
            var x when x % 5 == 0 => (x, "Buzz"),
            _ => (value, value.ToString())
        };


    /// <summary>
    /// Returns async the fizz-buzzed value
    /// </summary>
    /// <param name="value">An integer value</param>
    public static Task<(int, string)> ToFizzBuzzAsync(this int value) =>
        Task.FromResult(value.ToFizzBuzz());
}