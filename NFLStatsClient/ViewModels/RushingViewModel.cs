﻿using NFLStats.Model.Models;

namespace NFLStats.Client.ViewModels
{
    public class RushingViewModel
    {
        public int PageNumber { get; set; }

        public bool SortAscending { get; set; } = false;

        public string PlayerNameFilter { get; set; } = "";

        public string SortBy { get; set; } = "Yards";

        public List<RushingRecord> RushingRecords { get; set; } = new List<RushingRecord>();
    }
}
