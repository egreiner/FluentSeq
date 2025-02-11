namespace FluentSeq.UnitTests.FindTheArchitecture.Spike3;

using FluentSeq.FindTheArchitecture.Spike3;

public sealed class SimpleStateBuilderTests
{
    // public bool LastValue { get; set; }
    //
    // public TimeSpan OnDelay { get; set; } = TimeSpan.FromMilliseconds(10);


    [Fact]
    public void SequenceBuilder_State_ShouldReturn_StateBuilder()
    {
        var actual = new FluentSeq<string>().Create("INIT")
            .State("State1");

        actual.ShouldBeOfType<StateBuilder<string>>();
    }


    [Fact]
    public void StateBuilder_Builder_ShouldReturn_RootSequenceBuilder()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.State("State1").Builder();

        actual.ShouldBe(builder);
    }

    [Fact]
    public void StateBuilder_Builder_ShouldReturn_RootSequenceBuilder_when_nested()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.State("State1")
            .State("State2").Builder();

        actual.ShouldBe(builder);
    }

    [Fact]
    public void StateBuilder_ShouldReturn_State_with_correct_name()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var state = builder.State("State1").StateX;
        var actual = state.Name;

        actual.ShouldBe("State1");
    }


    [Fact]
    public void StateBuilder_ShouldReturn_State_with_correct_name_when_nested()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var state = builder.State("State1")
                           .State("State2").StateX;
        var actual = state.Name;

        actual.ShouldBe("State2");
    }

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