using E.Stadium.Abstraction.Exceptions;
using PhoneNumbers;

namespace E.Stadium.Abstraction.Utilities;

public class PhoneParser : IPhoneParser
{
    public string Parse(string phone, string region)
    {
        if (string.IsNullOrWhiteSpace(region))
        {
            throw new InvalidPhoneException(region);
        }

        try
        {
            region = region.ToUpper();
            PhoneNumberUtil instance = PhoneNumberUtil.GetInstance();
            PhoneNumber number = instance.Parse(phone, region);
            if (!instance.IsValidNumber(number))
            {
                throw new InvalidPhoneException(phone);
            }

            return instance.Format(number, PhoneNumberFormat.E164);
        }
        catch (Exception)
        {
            throw new InvalidPhoneException(phone);
        }
    }

    public string Parse(string phone)
    {
        return Parse(phone, "");
    }
}
