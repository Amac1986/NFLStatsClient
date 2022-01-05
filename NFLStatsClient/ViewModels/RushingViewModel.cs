using NFLStats.Model.Models;

namespace NFLStats.Client.ViewModels
{
    public class RushingViewModel
    {
        public RushingViewModel(IEnumerable<Record> records) 
        {
            StatTable = new StatTableViewModel(records);
        }

        public RushingViewModel()
        {
            StatTable = new StatTableViewModel(new List<RushingRecord>());
        }

        public int PageNumber { get; set; } = 1;

        public bool SortAscending { get; set; } = false;

        public string PlayerNameFilter { get; set; } = "";

        public string SortBy { get; set; } = "Yards";

        public StatTableViewModel StatTable { get; set; }
    }
}
