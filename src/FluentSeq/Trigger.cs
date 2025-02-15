namespace FluentSeq;

/// <summary>
/// Describes a trigger, how a state can be set as current state
/// </summary>
/// <typeparam name="TState"></typeparam>
public class Trigger<TState>
{
    private readonly IStateBuilder<TState> _stateBuilder;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trigger{TState}"/> class.
    /// </summary>
    /// <param name="stateBuilder">The root of this trigger builder</param>
    public Trigger(IStateBuilder<TState> stateBuilder)
    {
        _stateBuilder = stateBuilder;
    }


    /// <summary>
    /// Gets a list of states in which the sequence can be for the trigger to be valid.
    /// </summary>
    public IList<TState> WhenInStates { get; } = new List<TState>();
}