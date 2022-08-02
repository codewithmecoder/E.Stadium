using E.Stadium.Core.Entities.FileUploads;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Postgres.FileUploads;

namespace E.Stadium.Infrastructure.Repositories;

public class FileUploadFieldRepository : IFileUploadFieldRepository
{
    private readonly IPostgresRepository<FieldMediaTable> _repository;

    public FileUploadFieldRepository(IPostgresRepository<FieldMediaTable> repository)
    {
        _repository = repository;
    }
    public Task UpdateFieldImageAsync(FieldMediaEntity mediaEntity)
    => _repository.AddAsync(mediaEntity.AsTable());
}
