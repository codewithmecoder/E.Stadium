using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Commands.Stadiums;
using E.Stadium.Application.Queries.Stadiums;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
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
                isActive: true
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

        //[HttpGet("all")]
        //public async Task<ActionResult<StadiumEntity>> GetStadiumAsync()
        //{
        //    //var query = new GetStadiumByIdQuery(id);
        //    //var user = await _query.QueryAsync(query);
        //    //return Ok(user);
        //}
    }
}
