using Microsoft.AspNetCore.Mvc;
using NewWebApi.Data;
using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly INewApiRepository _repository;

        public CommandsController(INewApiRepository repository)
        {
            _repository = repository;
        }

        //GET api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var objcommand = _repository.GetAllCommands();
            return Ok(objcommand);
        }

        //GET api/Commands/2
        [HttpGet("{Id}")]
        public ActionResult<Command> GetCommandById(int Id)
        {
            var objcommandById = _repository.GetCommandById(Id);
            return Ok(objcommandById);
        }

    }
}
