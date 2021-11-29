using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NFLStats.Model.Models
{
    public class RushingRecord
    {
        [Required]
        [JsonProperty(PropertyName = "Player")]

        public string PlayerName { get; set; } = "";

        [Required]
        [JsonProperty(PropertyName = "Team")]
        public string TeamName { get; set; } = "";

        [Required]
        [JsonProperty(PropertyName = "Pos")]
        public string Position { get; set; } = "";

        [JsonProperty(PropertyName = "Att")]
        public int Attempts { get; set; }

        [JsonProperty(PropertyName = "Att/G")]
        public float AttemptsPerGame { get; set; }

        [JsonProperty(PropertyName = "Yds")] 
        public string Yds { get; set; } = "0";

        public int Yards => int.Parse(Yds. Replace(",", ""));

        [JsonProperty(PropertyName = "Avg")]
        public float AverageYards { get; set; }

        [JsonProperty(PropertyName = "Yds/G")]
        public float YardsPerGame { get; set; }

        [JsonProperty(PropertyName = "TD")]
        public int TouchDowns { get; set; }

        [JsonProperty(PropertyName = "Lng")]
        public string LongestRun { get; set; } = "0";

        [JsonProperty(PropertyName = "1st")]
        public int FirstDowns { get; set; }

        [JsonProperty(PropertyName = "1st%")]
        public float PercentageFirstDowns { get; set; }

        [JsonProperty(PropertyName = "20+")]
        public int Runs20Plus { get; set; }

        [JsonProperty(PropertyName = "40+")]
        public int Runs40Plus { get; set; }

        [JsonProperty(PropertyName = "FUM")]
        public int Fumbles { get; set; }


    }
}
