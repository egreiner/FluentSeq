namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods for configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    private readonly TState _initialState;

    public SequenceBuilder(TState initialState)
    {
        _initialState = initialState;
    }

    protected SequenceBuilder() : this(default!) { }



    public IStateBuilder<TState> State(TState state) => new StateBuilder<TState>(this);

    public virtual ISequenceBuilder<TState> Builder() => this;
}