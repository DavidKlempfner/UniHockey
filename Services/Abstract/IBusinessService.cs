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
        List<Player> GetAllPlayers();
        List<Player> GetPlayers(int teamId);        
        List<Team> GetAllTeams();
        List<Team> GetAllTeamsWithPlayers();
        Team GetTeamWithPlayers(int teamId);
        void Save(Game game);

        IEnumerable<Tuple<string, int>> GetTeamsWithPointsBroughtToNextTournament();
    }
}
