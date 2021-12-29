using NFLStats.Model.Models;

namespace NFLStats.Client.ViewModels
{
    public class StatTableViewModel
    {
        public StatTableViewModel(List<Record> records)
        {
            Records = records;
        }
        public List<Record> Records { get; set; }
    }
}
