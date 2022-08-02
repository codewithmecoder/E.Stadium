using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Infrastructure.Postgres.FileUploads;
using E.Stadium.Infrastructure.Postgres.User;

namespace E.Stadium.Infrastructure.Postgres.Stadiums;

public static class Extensions
{
    public static StadiumTable AsTable(this StadiumEntity x)
       => new(
            id: x.Id,
            userId: x.UserId,
            totalFields: x.TotalFields,
            name: x.Name,
            description: x.Description,
            lat: x.Lat,
            lon: x.Lon,
            createdAt: x.CreatedAt,
            updatedAt: x.UpdatedAt,
            address: x.Address,
            isActive: x.IsActive,
            startTime: x.StartTime,
            endTime: x.EndTime
           )
       {
           Fields = x.Fields.Where(i => i.IsActive).Select(i => i.AsTable()),
           StadiumMedias = x.StadiumMedias.Where(i=> i.IsActive).Select(i => i.AsTable()),
           User = x.User?.AsTable()
       };
    public static StadiumEntity AsEntity(this StadiumTable x)
        => new(
            id: x.Id,
            userId: x.UserId,
            name: x.Name,
            description: x.Description,
            lat: x.Lat,
            lon: x.Lon,
            createdAt: x.CreatedAt,
            updatedAt: x.UpdatedAt,
            address: x.Address,
            isActive: x.IsActive,
            startTime: x.StartTime,
            endTime: x.EndTime
            )
        {
            Fields = x.Fields.Where(i => i.IsActive).Select(i => i.AsEntity()),
            StadiumMedias = x.StadiumMedias.Where(i => i.IsActive).Select(i => i.AsEntity()),
            User = x.User?.AsEntity()
        };
    public static ResponseStadiumDto AsDto(this StadiumEntity x)
    => new(
        id: x.Id,
        userId: x.UserId,
        totalFields: x.TotalFields,
        name: x.Name,
        description: x.Description,
        lat: x.Lat,
        lon: x.Lon,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        address: x.Address,
        isActive: x.IsActive,
        startTime: x.StartTime,
        endTime: x.EndTime
       )
    {
        Fields = x.Fields?.Where(i => i.IsActive).Select(i => i.AsDto()),
        StadiumMedias = x.StadiumMedias?.Where(i => i.IsActive).Select(i=> i.AsDto()),
    };
    public static FieldTable AsTable(this FieldEntity x)
    => new(
        id: x.Id,
        stadiumId: x.StadiumId,
        numberOfPoeple: x.NumberOfPoeple,
        size: x.Size,
        name: x.Name,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    {
        Stadium = x.Stadium?.AsTable(),
        FieldMedias = x.FieldMedias?.Where(i => i.IsActive).Select(i => i.AsTable())
    };

    public static FieldEntity AsEntity(this FieldTable x)
    => new(
        id: x.Id,
        stadiumId: x.StadiumId,
        numberOfPoeple: x.NumberOfPoeple,
        size: x.Size,
        name: x.Name,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    {
        Stadium = x.Stadium?.AsEntity(),
        FieldMedias = x.FieldMedias?.Where(i => i.IsActive).Select(i => i.AsEntity())
    };

    public static ResponseFieldDto AsDto(this FieldEntity x)
        => new(
            id: x.Id,
            stadiumId: x.StadiumId,
            numberOfPoeple: x.NumberOfPoeple,
            size: x.Size,
            name: x.Name,
            createdAt: x.CreatedAt,
            updatedAt: x.UpdatedAt,
            isActive: x.IsActive
            )
        {
            FieldMedias = x.FieldMedias?.Where(i=> i.IsActive).Select(i=> i.AsDto()),
        };
}
