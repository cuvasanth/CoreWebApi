using AutoMapper;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Nest;
using NewWebApi.Data;
using NewWebApi.Dtos;
using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace NewWebApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly INewApiRepository _repository;

        private readonly IMapper _mapper;

        public CommandsController(INewApiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/Commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var objcommand = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(objcommand));
        }

        //GET api/Commands/{id}
        [HttpGet("{Id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int Id)
        {
            var objcommandById = _repository.GetCommandById(Id);
            if (objcommandById != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(objcommandById));
            }
            else
                return NotFound();
        }

        //POST api/Commands
        [HttpPost]
        public ActionResult<CommandCreateDTO> CreateCommand(CommandCreateDTO objcmdcreateDTO)
        {
            var commandModel = _mapper.Map<Command>(objcmdcreateDTO);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDto = _mapper.Map<CommandReadDTO>(commandModel);
            //return Ok(CommandReadDto);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = CommandReadDto.Id }, CommandReadDto);


        }

        //GET api/Commands/{id}
        [HttpPut("{Id}")]
        public ActionResult UpdateCommand(int Id, CommandUpdateDto ObjCmdcreateDto)
        {
            var objUpdatecommandById = _repository.GetCommandById(Id);
            if (objUpdatecommandById == null)
            {
                return NotFound();
            }

            _mapper.Map(ObjCmdcreateDto, objUpdatecommandById);

            _repository.UpdateCommand(objUpdatecommandById);

            _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int Id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var objUpdatePartialCommand = _repository.GetCommandById(Id);
            if (objUpdatePartialCommand == null)
            {
                return NotFound();
            }
            var commandPatch = _mapper.Map<CommandUpdateDto>(objUpdatePartialCommand);
            patchDoc.ApplyTo(commandPatch, ModelState);
            if (!TryValidateModel(commandPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandPatch, objUpdatePartialCommand);

            _repository.UpdateCommand(objUpdatePartialCommand);

            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var objdelete = _repository.GetCommandById(Id);
            if(objdelete == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(objdelete);
            _repository.SaveChanges();

            return NoContent();
            
        }
    }
}
