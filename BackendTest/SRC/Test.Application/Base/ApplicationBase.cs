using FluentValidation.Results;

namespace Test.Application.Base;

public  abstract class ApplicationBase
{
    protected ValidationResult ValidationResult;

    protected ApplicationBase()
    {
        ValidationResult = new ValidationResult();
    }

    protected void AdicionarErroValidation(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }
}
