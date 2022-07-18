namespace E.Stadium.Core.Dto.TestThread;

public static class AppCounts
{
    public static int Counter { get; set; }
    public static List<int> Counts { get; set; } = new List<int>();

    public static IEnumerable<IGrouping<int, int>> GetCounts()
    {
        return Counts?.GroupBy(i => i)!;
    }

    //public static async Task Increment()
    //{
    //    await Task.Factory.StartNew(() => Counter++, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
    //}
}
