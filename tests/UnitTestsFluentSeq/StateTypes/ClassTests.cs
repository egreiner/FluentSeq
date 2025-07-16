namespace UnitTestsFluentSeq.StateTypes;

public sealed class ClassTests
{
    [Fact]
    public void Use_Class_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<MyClass>().Create(new MyClass("Initial State"))
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }

    private class MyClass(string state)
    {
        public string State { get; set; } = state;

        /// <inheritdoc />
        public override string ToString() => State;
    }
}