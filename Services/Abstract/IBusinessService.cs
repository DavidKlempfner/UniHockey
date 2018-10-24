using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBusinessService
    {
        List<PlayerDto> GetPlayers();
        List<TeamDto> GetTeamsWithPlayers();
        List<TeamDto> GetTeams();
    }
}
