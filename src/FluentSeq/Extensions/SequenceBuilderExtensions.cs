namespace FluentSeq.Extensions;

using Builder;

/// <summary>
/// ExtensionMethods for the SequenceBuilder.
/// </summary>
public static class SequenceBuilderExtensions
{
    /// <summary>
    /// Returns true if the state should be validated.
    /// </summary>
    /// <param name="builder">The sequence builder</param>
    /// <param name="state">The specified state</param>
    public static bool IsStateValidationRequired<TState>(this ISequenceBuilder<TState> builder , TState state) =>
        !builder.Options.DisableValidation &&
        !builder.Options.DisableValidationForStates.Contains(state);
}