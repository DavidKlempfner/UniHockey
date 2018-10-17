using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniHockey.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int GoalsToDate { get; set; }
    }
}