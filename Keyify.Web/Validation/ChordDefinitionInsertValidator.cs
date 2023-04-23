using FluentValidation;
using Keyify.Infrastructure.DTOs.ChordDefinition;

namespace Keyify.Web.Validation
{
    public class ChordDefinitionInsertValidator : AbstractValidator<ChordDefinitionInsertRequestDto>
    {
        public ChordDefinitionInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Intervals).NotEmpty().NotNull();
        }
    }
}
