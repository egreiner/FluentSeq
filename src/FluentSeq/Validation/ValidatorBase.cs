﻿namespace FluentSeq.Validation;

/// <summary>
/// The handler validator base class.
/// </summary>
public class ValidatorBase
{
    // private List<IHasToState> _handlerTo;
    //
    //
    // /// <summary>
    // /// Each 'ToState' must have a corresponding 'FromState' counterpart,
    // /// otherwise you have created a dead-end.
    // /// Use '!' as first character to tag a state as dead-end with purpose.
    // /// </summary>
    // protected (bool isValid, IEnumerable<T> list) HandlerIsValidatedTo<T>(SequenceBuilder builder) where T: IHasToState
    // {
    //     var containsTransitions = builder.Data.Handler.OfType<T>().ToList();
    //     if (containsTransitions.Count == 0)
    //         return (true, Enumerable.Empty<T>());
    //
    //     var transitions = builder.Data.Handler.OfType<StateTransitionHandler>().ToList();
    //
    //     _handlerTo = new List<IHasToState>();
    //
    //
    //     AddMissingTransitions(builder, containsTransitions, transitions);
    //
    //     if (_handlerTo.Count == 0)
    //         return (true, Enumerable.Empty<T>());
    //
    //
    //     RemoveWithContainsTransitions(builder, containsTransitions);
    //
    //     if (_handlerTo.Count == 0)
    //         return (true, Enumerable.Empty<T>());
    //
    //
    //     RemoveWithAnyTransitions(builder, containsTransitions);
    //
    //     return (_handlerTo.Count == 0, _handlerTo.ConvertAll(x => (T)x));
    // }
    //
    //
    // private void AddMissingTransitions<T>(SequenceBuilder builder, List<T> containsTransitions,
    //     List<StateTransitionHandler>                      transitions)
    //     where T : IHasToState
    // {
    //     // for easy reading do not simplify this
    //     // each StateTransition should have a counterpart so that no dead-end is reached
    //     foreach (var transition in containsTransitions.Where(x => ValidationRequiredFor(x.ToState, builder)))
    //     {
    //         if (transitions.All(x => transition.ToState != x.FromState))
    //             _handlerTo.Add(transition);
    //     }
    // }
    //
    // private void RemoveWithAnyTransitions<T>(SequenceBuilder builder, List<T> containsTransitions)
    //     where T : IHasToState
    // {
    //     foreach (var transition in containsTransitions.Where(x => ValidationRequiredFor(x.ToState, builder)))
    //     {
    //         if (builder.Data.Handler.OfType<AnyStateTransitionHandler>().Any(x => x.FromStates.Contains(transition.ToState)))
    //             _handlerTo.Remove(transition);
    //     }
    // }
    //
    // private void RemoveWithContainsTransitions<T>(SequenceBuilder builder, List<T> containsTransitions)
    //     where T : IHasToState
    // {
    //     foreach (var transition in containsTransitions.Where(x => ValidationRequiredFor(x.ToState, builder)))
    //     {
    //         if (builder.Data.Handler.OfType<ContainsStateTransitionHandler>()
    //             .Any(x => transition.ToState.Contains(x.FromStateContains)))
    //             _handlerTo.Remove(transition);
    //     }
    // }
}