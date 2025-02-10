namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleBuilderTests
{
    public bool LastValue { get; set; }

    public TimeSpan OnDelay { get; set; } = TimeSpan.FromMilliseconds(10);



    [Fact]
    public void FluentSeq_Create_SequenceBuilder_Should_NotThrow()
    {
        var actual = () => new FluentSeq<string>().Create("INIT");

        actual.ShouldNotThrow();
    }


    [Fact]
    public void FluentSeq_Create_State_Should_NotThrow()
    {
        var actual = () => new FluentSeq<string>().Create("INIT")
            .State("State1");

        actual.ShouldNotThrow();
    }

    //
    // private ISequenceBuilder<string> GetSequenceBuilder2 =>
    //     new FluentSeq<string>().Create("Off")
    //         .State("bla")
    //         .WhileInState(() => Console.WriteLine("bla WhileInState"))
    //         .TriggeredBy(() => OnDelay == TimeSpan.Zero).WhenInState("dadd")
    //
    //         .State("blub")
    //         .TriggeredBy(() => OnDelay == TimeSpan.Zero).WhenInStates("dadd", "bla")
    //         .OnEntry(() => Console.WriteLine("blub entry"))
    //         .OnExit(() => Console.WriteLine("blub exit"));
}