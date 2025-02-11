namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods for further describing a state
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IStateBuilder<TState>: ISequenceBuilder<TState>, IActionBuilder<TState>
{
    ITriggerBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc);
}