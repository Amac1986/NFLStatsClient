using NFLStats.Model.Models;

namespace NFLStats.Client.ViewModels
{
    public class RushingViewModel
    {
        public int PageNumber { get; set; } = 1;

        public bool SortAscending { get; set; } = false;

        public string PlayerNameFilter { get; set; } = "";

        public string SortBy { get; set; } = "Yards";

        public StatTableViewModel StatTable { get; set; }

        //public List<RushingRecord> RushingRecords { get; set; } = new List<RushingRecord>();
    }
}
