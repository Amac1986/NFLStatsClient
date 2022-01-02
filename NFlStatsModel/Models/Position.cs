using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Model.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string PostionCode { get; set; }
        public string PositionName { get; set; }

        //Offense
        //public const string RunningBack = "RB";
        //public const string QuarterBack = "QB";
        //public const string WideReceiver = "WR";
        //public const string TightEnd = "TE";
        //public const string OffensiveTackle = "OE";
        //public const string OffensiveGuard = "OG";
        //public const string Centre = "C";

        ////Defense
        //public const string DefensiveEnd = "DE";
        //public const string DefensiveTackle = "DT";
        //public const string OutsideLinebacker = "OLB";
        //public const string MiddleLinebacker = "MLB";
        //public const string CornerBack = "CB";
        //public const string Safety = "S";

        ////Special Teams
        //public const string Kicker = "K";
        //public const string KickOffSpecialist = "KOS";
        //public const string Punter = "P";
        //public const string Holder = "H";
        //public const string LongSnapper = "LS";
        //public const string KickReturn = "KR";
        //public const string PuntReturn = "PR";
    }
}
