using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Shared.Postgres;

public static class Extension
{
    public static Guid ToGuid(this string? id)
    {
        if (!Guid.TryParse(id, out var result))
        {
            throw new InvalidGuidException(id ?? "empty");
        }

        return result;
    }
}
