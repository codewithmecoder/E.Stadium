using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User
{
    public class FailToDeleteUserException : BaseException
    {
        public override string Code => "can_not_delete_yourself";
    }
}
