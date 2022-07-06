using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Stadium.Abstraction.Exceptions
{
    public class InvalidPhoneException : BaseException
    {
        public override string Code => "invalid_phone";

        public InvalidPhoneException(string phone)
            : base("Invalid phone number " + phone)
        {
        }

        public InvalidPhoneException()
        {
        }

        public InvalidPhoneException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
