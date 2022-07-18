using E.Stadium.Core.Dto.TestThread;
using E.Stadium.Infrastructure.Services;
using System.Diagnostics;

namespace E.Stadium.Infrastructure.Repositories;

public interface ITaskThreadRepo
{
    Task<int> GetCount();
}
public class TaskThreadRepo : ITaskThreadRepo
{
    private readonly TestThreadWithSingletonService _service;
    private readonly object _lock = new();

    public TaskThreadRepo(TestThreadWithSingletonService service)
    {
        _service = service;
    }

    public Task<int> GetCount()
    {
        Task.Run(() =>
        {
            _service.IncrementCount();
            _service.AddCount();
            Debug.WriteLine(_service.Counter);
        });
        return Task.FromResult(0);
    }
}
