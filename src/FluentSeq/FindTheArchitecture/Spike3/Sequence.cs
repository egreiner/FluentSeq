namespace FluentSeq.FindTheArchitecture.Spike3;

/// <summary>
/// A sequence that could be executed
/// </summary>
/// <typeparam name="TSTate">Type of the state (string, enum, int...)</typeparam>
public class Sequence<TSTate> : ISequence<TSTate>
{
    // /// <inheritdoc />
    // public SequenceOptions<TSTate> Options { get; }
    //
    // /// <inheritdoc />
    // public TSTate CurrentState { get; }
    //
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
    //
    // /// <inheritdoc />
    // public ISequence<TSTate> SetState(TSTate state)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // /// <inheritdoc />
    // public ISequence<TSTate> SetState(TSTate state, Func<bool> constraint)
    // {
    //     throw new NotImplementedException();
    // }
}