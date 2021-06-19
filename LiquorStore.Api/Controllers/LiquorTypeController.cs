using LiquorStore.Application;
using LiquorStore.Application.Commands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiquorStore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LiquorTypeController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LiquorTypeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<LiquorTypeController>
        [HttpGet]
        public IActionResult Get([FromQuery] LiquorTypeSearch search, [FromServices] IGetLiquorTypesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<LiquorTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleLiquorType query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<LiquorTypeController>
        [HttpPost]
        public IActionResult Post([FromBody] LiquorTypeDto dto, [FromServices] ICreateLiquorTypeCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<LiquorTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LiquorTypeDto dto, [FromServices] IUpdateLiquorTypeCommand command)
        {
            dto.Id = id;

            _executor.ExecuteCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<LiquorTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLiquorTypeCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
