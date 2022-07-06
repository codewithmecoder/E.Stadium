namespace E.Stadium.Abstraction.Utilities;

public interface IPhoneParser
{
    string Parse(string phone, string region);

    string Parse(string phone);
}
