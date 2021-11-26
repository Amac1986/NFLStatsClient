using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Model.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int  Height { get; set; }
        public int Weight { get; set; }
    }
}
