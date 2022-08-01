using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Stadiums;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres.Stadiums;

namespace E.Stadium.Infrastructure.QueryHandler.Stadiums;

public class GetStadiumByIdQueryHandler : IQueryHandler<GetStadiumByIdQuery, ResponseStadiumDto>
{
    private readonly IStadiumRepository _stadiumRepository;

    public GetStadiumByIdQueryHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<ResponseStadiumDto> HandleAsync(GetStadiumByIdQuery query)
    {
        var data = await _stadiumRepository.GetByIdAsync(query.Id, query.UserId);
        return data.AsDto();
    }
}
