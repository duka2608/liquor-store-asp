using LiquorStore.Application;
using LiquorStore.Application.Commands.ILiquorCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Queries.ILiquorQueries;
using LiquorStore.Application.Searches;
using LiquorStore.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiquorStore.Api.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class LiquorsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LiquorsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<LiquorController>
        [HttpGet]
        public IActionResult Get([FromQuery] LiqourSearch search, [FromServices] IGetLiquorsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<LiquorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleLiquorQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<LiquorController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] LiquorDto dto, [FromServices] ICreateLiquorCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<LiquorController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LiquorDto dto, [FromServices] IUpdateLiquorCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<LiquorController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLiquorCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
