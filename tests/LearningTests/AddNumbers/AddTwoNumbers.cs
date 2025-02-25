namespace LearningTests.AddNumbers;

public sealed class AddTwoNumbers
{
    /// <summary>
    /// Two numbers are added
    /// Context:
    /// Two numbers are added, the simplest way possible.
    /// </summary>
    [Fact]
    public void AddTwoNumbers_ShouldReturn_TheSum()
    {
        var actual = 1 + 2;

        actual.ShouldBe(3);
    }

    // /// <summary>
    // /// Add one too max int
    // /// </summary>
    // [Fact]
    // public void AddOneToMax_ShouldReturn_Min()
    // {
    //     var actual = int.MaxValue + 1;
    //
    //     actual.ShouldBe(int.MinValue);
    // }


    /// <summary>
    /// Add one too max int
    /// </summary>
    [Fact]
    public void Add1ToAlmostMax_ShouldReturn_Min()
    {
        var actual = int.MaxValue - 2;

        for (int i = 1; i <= 3; i++)
        {
            actual += 1;
        }

        actual.ShouldBe(int.MinValue);
    }


    // /// <summary>
    // /// Add one too max byte
    // /// </summary>
    // [Fact]
    // public void Add1ToAlmostByteMax_ShouldReturn_Min()
    // {
    //     var actual = byte.MaxValue - 2;
    //
    //     for (byte i = 1; i <= 3; i++)
    //     {
    //         actual += 1;
    //     }
    //
    //     actual.ShouldBe(byte.MinValue);
    // }
}