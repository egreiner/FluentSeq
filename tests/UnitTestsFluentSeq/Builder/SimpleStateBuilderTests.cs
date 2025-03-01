namespace UnitTestsFluentSeq.Builder;

using FluentSeq.Builder;

public sealed class SimpleStateBuilderTests
{
    [Fact]
    public void SequenceBuilder_State_ShouldReturn_StateBuilder()
    {
        var actual = new FluentSeq<string>().Create("INIT")
            .ConfigureState("State1");

        actual.ShouldBeOfType<StateBuilder<string>>();
    }

    [Fact]
    public void StateBuilder_Builder_ShouldReturn_RootSequenceBuilder()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.ConfigureState("State1").Builder();

        actual.ShouldBe(builder);
    }

    [Fact]
    public void StateBuilder_Builder_ShouldReturn_RootSequenceBuilder_when_nested()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var actual = builder.ConfigureState("State1")
                            .ConfigureState("State2")
                            .Builder();

        actual.ShouldBe(builder);
    }

    [Fact]
    public void StateBuilder_ShouldReturn_State_with_correct_name()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var state = builder.ConfigureState("State1").State;
        var actual = state.Name;

        actual.ShouldBe("State1");
    }

    [Fact]
    public void StateBuilder_ShouldReturn_State_with_correct_name_when_nested()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var state = builder.ConfigureState("State1")
                           .ConfigureState("State2").State;

        var actual = state.Name;

        actual.ShouldBe("State2");
    }


    [Fact]
    public void StateBuilder_ShouldReturn_State_with_empty_description()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var state = builder.ConfigureState("State1").State;
        var actual = state.Description;

        actual.ShouldBe(string.Empty);
    }

    [Fact]
    public void StateBuilder_ShouldReturn_State_with_empty_description_when_nested()
    {
        var builder = new FluentSeq<string>().Create("INIT");

        var state = builder.ConfigureState("State1")
                           .ConfigureState("State2").State;

        var actual = state.Description;

        actual.ShouldBe(string.Empty);
    }
}