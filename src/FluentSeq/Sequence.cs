namespace FluentSeq;

/// <summary>
/// A sequence that could be executed
/// </summary>
/// <typeparam name="TSTate">Type of the state (string, enum, int...)</typeparam>
public class Sequence<TSTate>(SequenceOptions<TSTate> options, IList<State> registeredStates) : ISequence<TSTate>
{
    /// <inheritdoc />
    public SequenceOptions<TSTate> Options { get; } = options;

    /// <inheritdoc />
    public IList<State> RegisteredStates { get; } = registeredStates;

    /// <inheritdoc />
    public TSTate CurrentState { get; private set; } = options.InitialState;

    // /// <inheritdoc />
    // public TSTate PreviousState { get; }
    //
    // /// <inheritdoc />
    // public bool HasCurrentState(TSTate state)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // /// <inheritdoc />
    // public ISequence<TSTate> Run()
    // {
    //     throw new NotImplementedException();
    // }

    /// <inheritdoc />
    public ISequence<TSTate> SetState(TSTate state)
    {
        // TODO: add validation if this state is registered, raise exception if not???
        CurrentState = state;
        return this;
    }

    // /// <inheritdoc />
    // public ISequence<TSTate> SetState(TSTate state, Func<bool> constraint)
    // {
    //     throw new NotImplementedException();
    // }
}