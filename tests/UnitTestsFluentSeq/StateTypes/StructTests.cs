namespace UnitTestsFluentSeq.StateTypes;

public sealed class StructTests
{
    [Fact]
    public void Use_Struct_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<MyStruct>().Create(new MyStruct("Initial State"))
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }

    private struct MyStruct(string state)
    {
        public string State { get; set; } = state;

        /// <inheritdoc />
        public override string ToString() => State;
    }
}