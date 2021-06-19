using LiquorStore.Application;
using LiquorStore.Application.Commands.ILiquorSizeCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries.ILiquorSizeQueries;
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
    public class LiquorSizeController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LiquorSizeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/<LiquorSizeController>
        [HttpGet]
        public  IActionResult Get([FromQuery] LiquorSizeSearch search, [FromServices] IGetLiquorSizesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<LiquorSizeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleLiquorSizeQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<LiquorSizeController>
        [HttpPost]
        public IActionResult Post([FromBody] LiquorSizeDto dto, [FromServices] ICreateLiquorSizeCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<LiquorSizeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LiquorSizeDto dto, [FromServices] IUpdateLiquorSizeCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<LiquorSizeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLiquorSizeCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
