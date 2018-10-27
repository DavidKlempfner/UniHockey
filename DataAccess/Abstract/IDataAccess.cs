using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDataAccess
    {
        List<PlayerDto> GetAllPlayerDtos();
        List<PlayerDto> GetPlayerDtos(int teamId);
        List<TeamDto> GetAllTeamDtos();
        TeamDto GetTeamDto(int id);
        void SaveGame(GameDto gameDto);
    }
}
