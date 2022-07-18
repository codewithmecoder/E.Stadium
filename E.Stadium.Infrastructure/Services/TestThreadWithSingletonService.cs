namespace E.Stadium.Infrastructure.Services;

public class TestThreadWithSingletonService
{
    public int Counter { get; set; }
    public List<int> Counts { get; set; } = new List<int>();

    public Task AddCount()
    {
        Counts.Add(Counter);
        return Task.CompletedTask;
    }
    public Task<IEnumerable<IGrouping<int, int>>> GetCounts()
    {
        return Task.FromResult(Counts?.GroupBy(i => i)!);
    }
    public Task IncrementCount()
    {
        Counter++;
        return Task.CompletedTask;
    }
}
