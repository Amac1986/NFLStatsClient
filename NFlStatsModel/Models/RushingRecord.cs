using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NFLStats.Model.Models
{
    public class RushingRecord : Record
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

        [JsonProperty(PropertyName = "Yds")]
        public string Yds { get; set; } = "0";

        public int Yards => int.Parse(Yds.Replace(",", ""));

        [JsonProperty(PropertyName = "Att")]
        public int Attempts { get; set; }

        [JsonProperty(PropertyName = "Att/G")]
        public float AttemptsPerGame { get; set; }

        [JsonProperty(PropertyName = "Avg")]
        public float AverageYards { get; set; }

        [JsonProperty(PropertyName = "Yds/G")]
        public float YardsPerGame { get; set; }

        [JsonProperty(PropertyName = "TD")]
        public int TouchDowns { get; set; }

        [JsonProperty(PropertyName = "Lng")]
        public string Lng { get; set; } = "0";

        public int LongestRun => int.Parse(Lng.Replace("T", ""));

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

        public override string GetCSVHead()
        {
            return string.Join(",", GetDisplayedHeadValues());
        }

        public override string GetHtmlHead()
        {
             var html = BuildHeadHtml(GetDisplayedHeadValues(), FilterProperty);
            return html.Replace("\"Lng\"", "\"LongestRun\"").Replace("\"Yds\"", "\"Yards\"");
            
        }

        public override string ToHtml(string element)
        {
            return BuildHtml(element, FilterProperty);
        }

        private string[] GetDisplayedHeadValues() 
        {
            return new string[] { "Player", "Team", "Pos", "Yds", "Att", "Att/G", "Avg", "Yds/G", "TD", "Lng", "1st", "1st%", "20+", "40+", "FUM" };
        }

        public override string ToCSV()
        {
            return string.Join(",", GetType().GetProperties().Where(FilterProperty).Select(p => p.GetValue(this)).ToArray());
        }

        private bool FilterProperty(System.Reflection.PropertyInfo property) 
        {
            return !(property.Name.Equals("Yards") || property.Name.Equals("LongestRun"));
        }
    }
}
