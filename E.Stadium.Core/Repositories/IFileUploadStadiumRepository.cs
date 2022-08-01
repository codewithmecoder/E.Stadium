using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.FileUploads;

namespace E.Stadium.Core.Repositories;

public interface IFileUploadStadiumRepository : IRepository<StadiumMediaEntity>
{
    Task UpdateStadiumImageAsync(StadiumMediaEntity mediaEntity);
}
