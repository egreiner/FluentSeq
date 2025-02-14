namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public class StateTests
{
    [Fact]
    public void Equals_SameName_ReturnsTrue()
    {
        var state1 = new State("TestState");
        var state2 = new State("TestState");

        state1.Equals(state2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_DifferentName_ReturnsFalse()
    {
        var state1 = new State("TestState1");
        var state2 = new State("TestState2");

        state1.Equals(state2).ShouldBeFalse();
    }


    [Fact]
    public void GetHashCode_SameName_ReturnsSameHashCode()
    {
        var state1 = new State("TestState");
        var state2 = new State("TestState");

        var actual = state1.GetHashCode();

        actual.ShouldBe(state2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentName_ReturnsDifferentHashCode()
    {
        var state1 = new State("TestState1");
        var state2 = new State("TestState2");

        var actual = state1.GetHashCode();

        actual.ShouldNotBe(state2.GetHashCode());
    }
}