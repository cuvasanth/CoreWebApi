using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApi.Data
{
    public class MockNewApiRepository : INewApiRepository
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command { Id = 0, HowTo = "Dummy", Line = "Dummy Line", Platform = "ummy Platfor" },
                new Command { Id = 1, HowTo = "Dummy", Line = "Dummy Line", Platform = "ummy Platfor" },
                new Command { Id = 2, HowTo = "Dummy", Line = "Dummy Line", Platform = "ummy Platfor" },
                new Command { Id = 3, HowTo = "Dummy", Line = "Dummy Line", Platform = "ummy Platfor" },
                new Command { Id = 4, HowTo = "Dummy", Line = "Dummy Line", Platform = "ummy Platfor" }
                 };
            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command { Id = 0, HowTo = "Dummy", Line = "Dummy Line", Platform = "ummy Platfor" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
