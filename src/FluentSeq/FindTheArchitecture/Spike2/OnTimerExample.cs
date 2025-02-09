namespace FluentSeq.FindTheArchitecture.Spike2;

public sealed class OnTimerExample
{
    // private readonly ISequence _sequence;
    private readonly DefaultSequenceStates _state = new();

    public OnTimerExample(TimeSpan onDelay)
    {
        OnDelay   = onDelay;
        // _sequence = SequenceConfig.Build();
    }

    public bool LastValue { get; set; }

    public TimeSpan OnDelay { get; set; }


    private ISequenceBuilder<string> GetSequenceBuilder =>
        new SequenceFactory<string>().Create(_state.Off)
            .State(_state.Deactivated)
            .TriggeredBy(() => OnDelay == TimeSpan.Zero)

            .State(_state.Off)
            .TriggeredBy(() => !LastValue)

            .State(_state.Pending)
            .TriggeredBy(() => LastValue)
            //.WhenInState(_state.Off)
            // .OnEntry(() => _sequence.Stopwatch.Restart())

            .State(_state.On)
    // .TriggeredBy(() => _sequence.Stopwatch.IsExpired(OnDelay)).WhenInState(_state.Pending)
            .Builder();



    private ISequenceBuilder<string> GetSequenceBuilder2 =>
        new SequenceFactory<string>().Create(_state.Off)
            .State("bla")
            .WhileInState(() => Console.WriteLine("bla WhileInState"))
            .TriggeredBy(() => OnDelay == TimeSpan.Zero).WhenInState("dadd")

            .State("blub")
            .TriggeredBy(() => OnDelay == TimeSpan.Zero).WhenInStates("dadd", "bla")
            .OnEntry(() => Console.WriteLine("blub entry"))
            .OnExit(() => Console.WriteLine("blub exit"));
}