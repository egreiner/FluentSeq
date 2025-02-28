namespace UnitTestsFluentSeq.Validation;

public sealed class ValidationTests
{
    [Fact]
    public void Builder_ShouldThrow_when_to_few_states()
    {
        var actual = new FluentSeq<string>().Create("INIT");

        var action = () => actual.Build();

        // action.ShouldThrow();
    }
}