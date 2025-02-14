namespace FluentSeq.FindTheArchitecture.Spike3;

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


    public IList<TState> WhenInStates { get; set; } = new List<TState>();
}