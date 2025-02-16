namespace FluentSeq.UnitTests.Builder;

public sealed class SequenceBuilderSetStateTests
{
    [Fact]
    public void Sequence_SetState_ShouldBe_test()
    {
        var sequence = new FluentSeq<string>().Create("INIT")
            .Build();

        sequence.SetState("TEST");

        var actual = sequence.CurrentState;
        actual.ShouldBe("TEST");
    }
}