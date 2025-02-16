namespace FluentSeq.Validation;

using Builder;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// The handler validator base interface.
/// </summary>
public interface IHandlerValidator<TState>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="result"></param>
    /// <returns>true if valid</returns>
    bool Validate(ValidationContext<ISequenceBuilder<TState>> builder, ValidationResult result);
}