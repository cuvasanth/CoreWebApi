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

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == Id);

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Ntings
        }
    }
}
