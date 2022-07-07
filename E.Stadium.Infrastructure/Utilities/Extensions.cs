namespace E.Stadium.Infrastructure.Utilities;

public static class Extensions
{
    public static string ToStringUtc(this DateTime time)
    {
        return $"DateTime({time.Ticks}, DateTimeKind.Utc)";
    }
}
