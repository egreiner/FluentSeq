namespace UnitTestsFluentSeq.Builder;

public sealed class SequenceBuilderSetStateTests
{
    [Fact]
    public void Sequence_SetState_ShouldBe_executed()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .Build();

        sequence.SetState("TEST");

        var actual = sequence.CurrentState;
        actual.ShouldBe("TEST");
    }

    [Theory]
    [InlineData(true, "TEST")]
    [InlineData(false, "INIT")]
    public void Sequence_SetStateConditional_ShouldBe_executed(bool condition, string expected)
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .Build();

        sequence.SetState("TEST", () => condition);

        var actual = sequence.CurrentState;
        actual.ShouldBe(expected);
    }
}