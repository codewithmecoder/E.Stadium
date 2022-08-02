using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.FileUploads;

namespace E.Stadium.Core.Repositories;

public interface IFileUploadFieldRepository : IRepository<FieldMediaEntity>
{
    Task UpdateFieldImageAsync(FieldMediaEntity mediaEntity);
}
