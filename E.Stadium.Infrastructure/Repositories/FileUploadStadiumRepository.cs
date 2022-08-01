using E.Stadium.Core.Entities.FileUploads;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Postgres.FileUploads;

namespace E.Stadium.Infrastructure.Repositories;

public class FileUploadStadiumRepository : IFileUploadStadiumRepository
{
    private readonly IPostgresRepository<StadiumMediaTable> _repository;

    public FileUploadStadiumRepository(IPostgresRepository<StadiumMediaTable> repository)
    {
        _repository = repository;
    }

    public Task UpdateStadiumImageAsync(StadiumMediaEntity mediaEntity)
    => _repository.AddAsync(mediaEntity.AsTable());
}
