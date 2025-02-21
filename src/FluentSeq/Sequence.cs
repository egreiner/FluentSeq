﻿namespace FluentSeq;

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

    // /// <inheritdoc />
    // public bool HasCurrentState(TState state)
    // {
    //     throw new NotImplementedException();
    // }


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

        return this;
    }


    /// <inheritdoc />
    public ISequence<TState> SetState(TState state)
    {
        // TODO: add validation if this state is registered, raise exception if not???
        PreviousState = CurrentState;
        CurrentState  = state;

        if (CurrentStateHasChanged() && RegisteredStates.HasItems())
            callAllEntryActions(CurrentState);

        return this;

        void callAllEntryActions(TState theState) =>
            RegisteredStates.GetSeqState(theState)?.EntryActions.ForEach(x => x());
    }

    private bool CurrentStateHasChanged() =>
        !CurrentState?.Equals(PreviousState) ?? false;


    /// <inheritdoc />
    public ISequence<TState> SetState(TState state, Func<bool> condition) =>
        condition() ? SetState(state) : this;
}