namespace FluentSeq.FindTheArchitecture.Spike3;

#pragma warning disable CS1591
/// <summary>
/// Provides methods to enhance a state with actions
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IActionBuilder<TState>
{
    IStateBuilder<TState> OnEntry(Action action);

    IStateBuilder<TState> OnExit(Action action);

    IStateBuilder<TState> WhileInState(Action action);
}