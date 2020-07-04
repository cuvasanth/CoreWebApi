using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApi.Data
{
    public interface INewApiRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
    }
}
