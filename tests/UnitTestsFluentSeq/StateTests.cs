namespace UnitTestsFluentSeq;

public class StateTests
{
    [Fact]
    public void Equals_SameName_ReturnsTrue()
    {
        var state1 = new SeqState<string>("TestState");
        var state2 = new SeqState<string>("TestState");

        state1.Equals(state2).ShouldBeTrue();
    }

    [Fact]
    public void Equals_DifferentName_ReturnsFalse()
    {
        var state1 = new SeqState<string>("TestState1");
        var state2 = new SeqState<string>("TestState2");

        state1.Equals(state2).ShouldBeFalse();
    }


    [Fact]
    public void GetHashCode_SameName_ReturnsSameHashCode()
    {
        var state1 = new SeqState<string>("TestState");
        var state2 = new SeqState<string>("TestState");

        var actual = state1.GetHashCode();

        actual.ShouldBe(state2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentName_ReturnsDifferentHashCode()
    {
        var state1 = new SeqState<string>("TestState1");
        var state2 = new SeqState<string>("TestState2");

        var actual = state1.GetHashCode();

        actual.ShouldNotBe(state2.GetHashCode());
    }
}