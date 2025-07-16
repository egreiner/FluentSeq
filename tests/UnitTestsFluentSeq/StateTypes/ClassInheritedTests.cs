namespace UnitTestsFluentSeq.StateTypes;

using FluentSeq.Core;

public sealed class ClassInheritedTests
{
    [Fact]
    public void Use_Class_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<MyInheritedClass>().Create(new MyInheritedClass("Initial State"))
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }

    private class MyInheritedClass(string state, string description = "") : SeqState<string>(state, description);
}