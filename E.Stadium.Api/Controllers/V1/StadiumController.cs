using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Commands.Stadiums;
using E.Stadium.Application.Queries.Stadiums;
using E.Stadium.Core.Dto.Base;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;
using Microsoft.AspNetCore.Mvc;
using Mip.Farm.Api.Controllers;

namespace E.Stadium.Api.Controllers.V1
{
    public class StadiumController : BaseController
    {
        private readonly ICommandDispatcher _command;
        private readonly IQueryDispatcher _query;

        public StadiumController(ICommandDispatcher command, IQueryDispatcher query)
        {
            _command = command;
            _query = query;
        }

        /// <summary>
        /// Create Stadium
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateStadium([FromBody] CreateStadiumDto dto)
        {
            var id = Guid.NewGuid();

            var cmd = new CreateStadiumCommand(
                id: id,
                userId: UserId,
                name: dto.Name,
                description: dto.Description,
                lat: dto.Lat,
                lon: dto.Lon,
                createdAt: DateTime.UtcNow,
                updatedAt: DateTime.UtcNow,
                address: dto.Address,
                isActive: true,
                startTime: dto.StartTime,
                endTime: dto.EndTime
                )
            {
                StadiumImageUrls = dto.StadiumImageUrls
            };
            await _command.PerformAsync(cmd);

            return AcceptedWithResource($"stadium/{id}", id.ToString());
        }

        /// <summary>
        /// get stadium by id and base on user login
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponseStadiumDto>> GetStadiumAsync(Guid id)
        {
            var query = new GetStadiumByIdQuery(id, UserId);
            var user = await _query.QueryAsync(query);
            return Ok(user);
        }

        /// <summary>
        /// get all active stadium
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<PagedResult<ResponseStadiumDto>>> GetStadiumAsync(string? filter, [FromQuery] BasePaginateDto dto)
        {
            var query = new GetAllStadiumByFilterQuery(filter, dto.Page, dto.Results);
            var user = await _query.QueryAsync(query);
            return Ok(user);
        }

        /// <summary>
        /// get all active stadium base on user login
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("all-by-user")]
        public async Task<ActionResult<PagedResult<ResponseStadiumDto>>> GetStadiumByUserAsync(string? filter, [FromQuery] BasePaginateDto dto)
        {
            var query = new GetAllStadiumByFilterBaseUserIdQuery(filter ?? string.Empty, UserId, dto.Page, dto.Results);
            var user = await _query.QueryAsync(query);
            return Ok(user);
        }

        /// <summary>
        /// update Stadium by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStadiumAsync(Guid id, [FromBody] UpdateStadiumDto dto)
        {
            var cmd = new UpdateStadiumCommand(
                id: id,
                userId: UserId,
                name: dto.Name,
                description: dto.Description,
                lat: dto.Lat,
                lon: dto.Lon,
                updatedAt: DateTime.UtcNow,
                address: dto.Address,
                startTime: dto.StartTime,
                endTime: dto.EndTime
                )
            {};
            await _command.PerformAsync(cmd);

            return AcceptedWithResource($"stadium/{id}", id.ToString());
        }

        /// <summary>
        /// Delete stadium
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DaleteFieldAsync(Guid id)
        {
            var cmd = new DeleteStadiumCommand(id, UserId);
            await _command.PerformAsync(cmd);
            return Accepted();
        }
    }
}
