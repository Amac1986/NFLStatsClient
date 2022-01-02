using NFLStats.Model.Models;

namespace NFLStats.Client.ViewModels
{
    public class StatTableViewModel
    {
        public StatTableViewModel(IEnumerable<Record> records)
        {
            Records = records;
        }
        public IEnumerable<Record> Records { get; set; }
    }
}
