using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Model.Models
{
    public class Rush
    {
        public int Id { get; set; }

        public Player Player { get; set; } = new Player();


        public string Yds { get; set; } = "0";

        public int Yards => int.Parse(Yds.Replace(",", ""));

        public int Attempts { get; set; }


        public float AttemptsPerGame { get; set; }


        public float AverageYards { get; set; }

        public float YardsPerGame { get; set; }


        public int TouchDowns { get; set; }


        public string Lng { get; set; } = "0";

        public int LongestRun => int.Parse(Lng.Replace("T", ""));


        public int FirstDowns { get; set; }


        public float PercentageFirstDowns { get; set; }


        public int Runs20Plus { get; set; }


        public int Runs40Plus { get; set; }


        public int Fumbles { get; set; }
    }
}
