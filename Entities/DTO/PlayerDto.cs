using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int NumOfGoals { get; set; }
    }
}