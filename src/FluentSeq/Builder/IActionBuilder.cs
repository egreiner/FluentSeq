namespace FluentSeq.Builder;

/// <summary>
/// Provides methods to enhance a state with actions
/// </summary>
/// <typeparam name="TState">The type of the state</typeparam>
public interface IActionBuilder<TState>
{
    /// <summary>
    /// Action that should be executed when the state is entered
    /// </summary>
    /// <param name="action">The action</param>
    IStateBuilder<TState> OnEntry(Action action);

    /// <summary>
    /// Action that should be executed when the state is exited
    /// </summary>
    /// <param name="action">The action</param>
    // IStateBuilder<TState> OnExit(Action action);
    //
    /// <summary>
    /// Action that should be executed during the state exists
    /// </summary>
    /// <param name="action">The action</param>
    // IStateBuilder<TState> WhileInState(Action action);
}