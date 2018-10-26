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
        List<PlayerDto> GetPlayerDtos();
        List<TeamDto> GetTeamDtos();
        void SaveGame(GameDto gameDto);
    }
}
