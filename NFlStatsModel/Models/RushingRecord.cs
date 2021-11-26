using System.ComponentModel.DataAnnotations;

namespace NFLStats.Model.Models
{
    public class RushingRecord
    {
        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int PositionId { get; set; }

        public int Attempts { get; set; }

        public int AttemptsPerGame { get; set; }

        public int Yards { get; set; }

        public int AverageYards { get; set; }

        public int YardsPerGame { get; set; }

        public int TouchDowns { get; set; }

        public string LongestRun { get; set; } = "0";

        public int FirstDowns { get; set; }

        public int PercentageFirstDowns { get; set; }

        public int Runs20Plus { get; set; }

        public int Runs40Plus { get; set; }

        public int Fumbles { get; set; }

    }
}
