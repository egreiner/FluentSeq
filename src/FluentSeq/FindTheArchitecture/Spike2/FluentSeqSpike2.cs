namespace FluentSeq.FindTheArchitecture.Spike2;

using System;

public interface IFluentSeqBuilder<in TState>
{
    IFluentSeqBuilder<TState> State(TState state);

    
    IFluentSeqBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc);

    IFluentSeqBuilder<TState> WhenInState(TState currentState);

    IFluentSeqBuilder<TState> WhenInStates(params TState[] currentStates);

    
    
    //IFluentSeqBuilder<TState> TriggeredFromState(Func<bool> triggeredByFunc, TState currentState);

    //IFluentSeqBuilder<TState> TriggeredFromStates(Func<bool> triggeredByFunc, params TState[] currentStates);



    IFluentSeqBuilder<TState> OnEntry(Action action);

    IFluentSeqBuilder<TState> OnExit(Action action);

    IFluentSeqBuilder<TState> WhileInState(Action action);



    IFluentSeqBuilder<TState> Builder();
}



public class FluentSeq<TState> : IFluentSeqBuilder<TState>
{

    public IFluentSeqBuilder<TState> Create(TState initialState) => new FluentSeq<TState>();



    public IFluentSeqBuilder<TState> State(TState state)
    {
        throw new NotImplementedException();
    }

    public IFluentSeqBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc)
    {
        throw new NotImplementedException();
    }

    public IFluentSeqBuilder<TState> WhenInState(TState currentState)
    {
        throw new NotImplementedException();
    }

    public IFluentSeqBuilder<TState> WhenInStates(params TState[] currentStates)
    {
        throw new NotImplementedException();
    }

    //public IFluentSeqBuilder<TState> TriggeredFromState(Func<bool> triggeredByFunc, TState currentState)
    //{
    //    throw new NotImplementedException();
    //}

    //public IFluentSeqBuilder<TState> TriggeredFromStates(Func<bool> triggeredByFunc, params TState[] currentStates)
    //{
    //    throw new NotImplementedException();
    //}

    public IFluentSeqBuilder<TState> Builder()
    {
        throw new NotImplementedException();
    }

    public IFluentSeqBuilder<TState> OnEntry(Action action)
    {
        throw new NotImplementedException();
    }

    public IFluentSeqBuilder<TState> OnExit(Action action)
    {
        throw new NotImplementedException();
    }

    public IFluentSeqBuilder<TState> WhileInState(Action action)
    {
        throw new NotImplementedException();
    }
}


// --------------------------------------------------------------------------------



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

    // public TimeSpan Elapsed   => IsRunning ? _sequence.Stopwatch.Elapsed : TimeSpan.Zero;
    // public TimeSpan Remaining => IsRunning ? OnDelay - _sequence.Stopwatch.Elapsed : OnDelay;
    //

    // public ITimer Set(TimeSpan onDelay)
    // {
    //     OnDelay = onDelay;
    //     return this;
    // }
    //
    // public ITimer In(bool value) =>
    //     InvokeTimerCalculations(LastValue = value).Timer;
    //
    //
    // protected override (ITimer Timer, bool Result) InvokeTimerCalculations(bool value)
    // {
    //     _sequence.Run();
    //     IsRunning = _sequence.HasCurrentState(_state.Pending);
    //     return (this,
    //                 _sequence.HasCurrentState(_state.Deactivated)
    //                     ? value
    //                     : _sequence.HasCurrentState(_state.On));
    // }


    private IFluentSeqBuilder<string> FluentSeqBuilder =>
        new FluentSeq<string>().Create(_state.Off)
            .State(_state.Deactivated)
            .TriggeredBy(() => OnDelay == TimeSpan.Zero)

            .State(_state.Off)
            .TriggeredBy(() => !LastValue)

            .State(_state.Pending)
            .TriggeredBy(() => LastValue).WhenInState(_state.Off)
            // .OnEntry(() => _sequence.Stopwatch.Restart())

            .State(_state.On)
            // .TriggeredBy(() => _sequence.Stopwatch.IsExpired(OnDelay)).WhenInState(_state.Pending)
            .Builder();
}