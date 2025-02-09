namespace FluentSeq.FindTheArchitecture.Spike2;

using System;


public interface ISequenceBuilder<in TState>
{
    IStateBuilder<TState> State(TState state);

    ISequenceBuilder<TState> Builder();
}

public interface IActionBuilder<in TState>
{
    IStateBuilder<TState> OnEntry(Action action);

    IStateBuilder<TState> OnExit(Action action);

    IStateBuilder<TState> WhileInState(Action action);
}


public interface IStateBuilder<in TState>: ISequenceBuilder<TState>, IActionBuilder<TState>
{
    IStateBuilder<TState> TriggeredBy(Func<bool> triggeredByFunc);
}
