using NFLStats.Model.Models;

namespace NFLStats.Client.ViewModels
{
    public class RushingViewModel
    {
        public int PageNumber { get; set; }

        public int SortDirection { get; set; }


        public List<RushingRecord> RushingRecords { get; set; } = new List<RushingRecord>();
    }
}
