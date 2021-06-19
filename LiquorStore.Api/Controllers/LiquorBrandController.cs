using LiquorStore.Application;
using LiquorStore.Application.Commands.ILiquorBrandCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries.ILiquorBrandQueries;
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
    public class LiquorBrandController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LiquorBrandController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/<LiquorBrandController>
        [HttpGet]
        public IActionResult Get([FromQuery] LiquorBrandSearch search, [FromServices] IGetLiquorBrandsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<LiquorBrandController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleLiquorBrandQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<LiquorBrandController>
        [HttpPost]
        public IActionResult Post([FromBody] LiquorBrandDto dto, [FromServices] ICreateLiquorBrandCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<LiquorBrandController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LiquorBrandDto dto, [FromServices] IUpdateLiquorBrandCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<LiquorBrandController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLiquorBrandCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
