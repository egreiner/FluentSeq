namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods to configure a sequence
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface ISequenceBuilder<in TState>
{
    IStateBuilder<TState> State(TState state);

    ISequenceBuilder<TState> Builder();
}