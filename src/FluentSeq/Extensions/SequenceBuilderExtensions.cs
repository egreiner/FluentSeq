namespace FluentSeq.Extensions;

using Builder;

/// <summary>
/// ExtensionMethods for the SequenceBuilder.
/// </summary>
public static class SequenceBuilderExtensions
{
    /// <summary>
    /// Returns true if validation for state is required.
    /// </summary>
    /// <param name="builder">The sequence builder</param>
    /// <param name="state">The specified state</param>
    public static bool ValidationRequiredFor<TState>(this ISequenceBuilder<TState> builder , TState state) =>
        !builder.Options.DisableValidation &&
        !builder.Options.DisableValidationForStates.Contains(state);


    /// <summary>
    /// Returns true if no validation for state is required.
    /// </summary>
    /// <param name="builder">The sequence builder</param>
    /// <param name="state">The specified state</param>
    public static bool NoValidationRequiredFor<TState>(this ISequenceBuilder<TState> builder , TState state) =>
        !builder.ValidationRequiredFor(state);
}