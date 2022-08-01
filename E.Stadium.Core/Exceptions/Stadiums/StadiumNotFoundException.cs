using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.Stadiums;

public class StadiumNotFoundException : BaseException
{
    public override string Code => "stadium_not_found";
    public StadiumNotFoundException(Guid id) : base($"Stadium with id {id} not found") { }
}
