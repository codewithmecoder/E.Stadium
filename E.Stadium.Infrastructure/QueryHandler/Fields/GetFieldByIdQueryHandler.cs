using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Fields;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Exceptions.Fields;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres.Stadiums;

namespace E.Stadium.Infrastructure.QueryHandler.Fields;

public class GetFieldByIdQueryHandler : IQueryHandler<GetFieldByIdQuery, ResponseFieldDto>
{
    private readonly IFieldRepository _fieldRepository;

    public GetFieldByIdQueryHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<ResponseFieldDto> HandleAsync(GetFieldByIdQuery query)
    {
        var data = await _fieldRepository.FindByIdAsync(query.Id);
        if (data == null) throw new FieldNotFoundException(query.Id);
        return data.AsDto();
    }
}
