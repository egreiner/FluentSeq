namespace UnitTestsFluentSeq.StateTypes;

public sealed class EnumTests
{
    [Fact]
    public void Use_Enum_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<MyStateEnum>().Create(MyStateEnum.State1)
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }

    private enum MyStateEnum
    {
        State1,
        State2
    }
}