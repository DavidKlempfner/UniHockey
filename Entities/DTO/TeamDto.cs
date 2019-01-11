using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.DTO
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerDto> Players { get; set; }        
    }
}