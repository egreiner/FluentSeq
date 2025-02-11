namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
public class Trigger<TState>
{
    private readonly IStateBuilder<TState> _stateBuilder;

    public Trigger(IStateBuilder<TState> stateBuilder)
    {
        _stateBuilder = stateBuilder;
    }
}