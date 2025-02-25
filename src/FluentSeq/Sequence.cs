namespace FluentSeq;

using Extensions;

/// <summary>
/// A sequence that could be executed
/// </summary>
/// <typeparam name="TState">Type of the state (string, enum, int...)</typeparam>
public class Sequence<TState>(SequenceOptions<TState> options, SeqStateCollection<TState> registeredStates) : ISequence<TState>
{
    /// <inheritdoc />
    public SequenceOptions<TState> Options { get; } = options;

    /// <inheritdoc />
    public SeqStateCollection<TState> RegisteredStates { get; } = registeredStates;

    /// <inheritdoc />
    public TState CurrentState { get; private set; } = options.InitialState;


    /// <inheritdoc />
    public TState? PreviousState { get; private set; }


    /// <inheritdoc />
    public bool IsInState(TState state) =>
        CurrentState?.Equals(state) ?? false;

    /// <inheritdoc />
    public bool IsInStates(params TState[] states) =>
        states.Contains(CurrentState);

    /// <inheritdoc />
    public virtual async Task<ISequence<TState>> RunAsync() =>
        await Task.Run(Run).ConfigureAwait(false);


    /// <inheritdoc />
    public ISequence<TState> Run()
    {
        foreach (var state in RegisteredStates)
        {
            if (state.Trigger.Any(x => x.IsTriggered(this)))
            {
                SetState(state.State);

                // if the first state is triggered, break the loop
                break;
            }
        }

        RegisteredStates.GetSeqState(CurrentState)?
            .WhileInStateActions.ForEach(x => x());

        return this;
    }


    /// <inheritdoc />
    public ISequence<TState> SetState(TState state)
    {
        // TODO: add validation if this state is registered, raise exception if not???
        PreviousState = CurrentState;
        CurrentState  = state;

        if (CurrentStateHasChanged() && RegisteredStates.HasItems())
        {
            callAllExitActions(PreviousState);
            callAllEntryActions(CurrentState);
        }

        return this;

        void callAllExitActions(TState theState) =>
            RegisteredStates.GetSeqState(theState)?.ExitActions.ForEach(x => x());

        void callAllEntryActions(TState theState) =>
            RegisteredStates.GetSeqState(theState)?.EntryActions.ForEach(x => x());
    }

    private bool CurrentStateHasChanged() =>
        !CurrentState?.Equals(PreviousState) ?? false;


    /// <inheritdoc />
    public ISequence<TState> SetState(TState state, Func<bool> condition) =>
        condition() ? SetState(state) : this;
}