using E.Stadium.Core.Dto.FieldUploads;
using E.Stadium.Core.Entities.FileUploads;
using E.Stadium.Infrastructure.Postgres.Stadiums;

namespace E.Stadium.Infrastructure.Postgres.FileUploads;

public static class Extensions
{
    public static FieldMediaTable AsTable(this FieldMediaEntity x)
    => new(
        id: x.Id,
        fieldId: x.StadiumId,
        fieldImageUrl: x.FieldImageUrl,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    {};
    public static FieldMediaEntity AsEntity(this FieldMediaTable x)
    => new(
        id: x.Id,
        stadiumId: x.FieldId,
        fieldImageUrl: x.FieldImageUrl,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    {};

    public static ResponseFieldMediaDto AsDto(this FieldMediaEntity x)
        => new(
            id: x.Id,
            stadiumId: x.StadiumId,
            fieldImageUrl: x.FieldImageUrl,
            createdAt: x.CreatedAt,
            updatedAt: x.UpdatedAt,
            isActive: x.IsActive
            )
        { };


    public static StadiumMediaTable AsTable(this StadiumMediaEntity x)
    => new(
        id: x.Id,
        stadiumId: x.StadiumId,
        stadiumImageUrl: x.StadiumImageUrl,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    {};
    public static StadiumMediaEntity AsEntity(this StadiumMediaTable x)
    => new(
        id: x.Id,
        stadiumId: x.StadiumId,
        stadiumImageUrl: x.StadiumImageUrl,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    {};

    public static ResponseStadiumMediaDto AsDto(this StadiumMediaEntity x)
    => new(
        id: x.Id,
        stadiumId: x.StadiumId,
        stadiumImageUrl: x.StadiumImageUrl,
        createdAt: x.CreatedAt,
        updatedAt: x.UpdatedAt,
        isActive: x.IsActive
        )
    { };
}
