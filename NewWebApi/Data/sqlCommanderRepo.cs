using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NewWebApi.Data
{
    public class sqlCommanderRepo : INewApiRepository
    {
        private readonly CommanderContext _context;

        public sqlCommanderRepo()
        {
        }

        public sqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == Id);

        }
    }
}
