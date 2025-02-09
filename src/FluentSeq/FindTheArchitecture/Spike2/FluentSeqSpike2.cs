namespace FluentSeq.FindTheArchitecture.Spike2;

using System;

public class SequenceFactory<TState>
{
    public ISequenceBuilder<TState> Create(TState initialState) => new SequenceBuilder<TState>();

}

public class SequenceBuilder<TState> : ISequenceBuilder<TState>
{
    // public SequenceBuilder(TState initialState)
    // {
    //     throw new NotImplementedException();
    // }

    public IStateBuilder<TState> State(TState state) => throw new NotImplementedException();

    /// <inheritdoc />
    public virtual ISequenceBuilder<TState> Builder() => this;
}


public class StateBuilder<TState> : SequenceBuilder<TState>, IStateBuilder<TState>
{
    private readonly ISequenceBuilder<TState> _sequenceBuilder;

    public StateBuilder(ISequenceBuilder<TState> sequenceBuilder)
    {
        _sequenceBuilder = sequenceBuilder;
    }

    public override ISequenceBuilder<TState> Builder() => _sequenceBuilder;


    public IStateBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc) => throw new NotImplementedException();

    public IStateBuilder<TState> OnEntry(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> OnExit(Action action) => throw new NotImplementedException();

    public IStateBuilder<TState> WhileInState(Action action) => throw new NotImplementedException();
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