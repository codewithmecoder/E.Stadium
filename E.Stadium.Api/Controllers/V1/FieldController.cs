using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Commands.Fields;
using E.Stadium.Application.Queries.Fields;
using E.Stadium.Core.Dto.Base;
using E.Stadium.Core.Dto.Fields;
using E.Stadium.Core.Dto.Stadiums;
using Microsoft.AspNetCore.Mvc;
using Mip.Farm.Api.Controllers;

namespace E.Stadium.Api.Controllers.V1
{
    
    public class FieldController : BaseController
    {
        private readonly ICommandDispatcher _command;
        private readonly IQueryDispatcher _query;

        public FieldController(ICommandDispatcher command, IQueryDispatcher query)
        {
            _command = command;
            _query = query;
        }
        /// <summary>
        /// Create Field base on stadium
        /// </summary>
        /// <param name="stadiumId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("{stadiumId:guid}")]
        public async Task<IActionResult> CreateAsync(Guid stadiumId, [FromBody] CreateFieldDto dto)
        {
            var id = Guid.NewGuid();
            var cmd = new CreateFieldCommand(
                id: id,
                stadiumId: stadiumId,
                numberOfPoeple: dto.NumberOfPoeple,
                size: dto.Size,
                name: dto.Name,
                createdAt: DateTime.UtcNow,
                updatedAt: DateTime.UtcNow,
                isActive: true
                )
            {
                FieldImageUrls = dto.FieldImageUrls,
            };
            await _command.PerformAsync(cmd);
            return AcceptedWithResource($"field/{id}", id.ToString());
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponseFieldDto>> GetByIdAsync(Guid id)
        {
            var q = new GetFieldByIdQuery(id);
            var data = await _query.QueryAsync(q);
            return Ok(data);
        }

        /// <summary>
        /// Get base stadium
        /// </summary>
        /// <param name="staduimid"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("{staduimid:guid}/base-on-stadium")]
        public async Task<ActionResult<ResponseFieldDto>> GetBaseOnStadiumAsync(Guid staduimid, [FromQuery] BasePaginateDto dto)
        {
            var q = new GetFieldBaseOnStadiumQuery(staduimid) { Page = dto.Page, Results = dto.Results};
            var data = await _query.QueryAsync(q);
            return Ok(data);
        }

        /// <summary>
        /// update by id and stadium id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stadiumId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}/{stadiumId:guid}")]
        public async Task<IActionResult> UpdateFieldAsync(Guid id, Guid stadiumId, [FromBody] UpdateFieldDto dto)
        {
            var cmd = new UpdateFieldCommand(
                id: id,
                stadiumId: stadiumId,
                numberOfPoeple: dto.NumberOfPoeple,
                size: dto.Size,
                name: dto.Name,
                updatedAt: DateTime.UtcNow
                );
            await _command.PerformAsync(cmd);
            return AcceptedWithResource($"field/{id}", id.ToString());
        }
        
        /// <summary>
        /// Delete Field
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DaleteFieldAsync(Guid id)
        {
            var cmd = new DeleteFieldCommand(id: id);
            await _command.PerformAsync(cmd);
            return Accepted();
        }

    }
}
