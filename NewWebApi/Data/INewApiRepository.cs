using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApi.Data
{
    public interface INewApiRepository
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
