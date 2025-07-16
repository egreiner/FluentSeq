namespace UnitTestsFluentSeq.StateTypes;

public sealed class PrimitiveTypeTests
{
    [Fact]
    public void Use_String_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<string>().Create("INIT")
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }


    [Fact]
    public void Use_Int_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<int>().Create(1)
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }
    
    [Fact]
    public void Use_Double_as_StateType_ShouldNotThrow()
    {
        var action = () => new FluentSeq<double>().Create(1.1)
            .DisableValidation()
            .Build();

        action.ShouldNotThrow();
    }
}