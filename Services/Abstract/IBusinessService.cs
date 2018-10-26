using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBusinessService
    {
        List<Player> GetPlayers();
        List<Team> GetTeamsWithPlayers();
        List<Team> GetTeams();
        void SaveGame(Game gameDto);
    }
}
