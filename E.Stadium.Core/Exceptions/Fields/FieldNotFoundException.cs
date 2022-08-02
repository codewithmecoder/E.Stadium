using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.Fields;

public class FieldNotFoundException : BaseException
{
    public override string Code => "field_not_found";

    public FieldNotFoundException(Guid id) : base($"Field with id {id} not found") { }
}
