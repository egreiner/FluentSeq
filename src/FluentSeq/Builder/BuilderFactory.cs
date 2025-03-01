namespace FluentSeq.Builder;

/// <summary>
/// A factory for creating all available builders
/// </summary>
public static class BuilderFactory<TState>
{
    private static ISequenceBuilder<TState>? _sequenceBuilder;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="initialState"></param>
    /// <typeparam name="TState"></typeparam>
    /// <returns></returns>
    public static ISequenceBuilder<TState> Create(TState initialState)
    {
        if (_sequenceBuilder is not null)
            return _sequenceBuilder;
        
        _sequenceBuilder = new SequenceBuilder<TState>(initialState);
        return _sequenceBuilder;
    }
}