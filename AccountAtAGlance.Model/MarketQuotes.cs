using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountAtAGlance.Model
{
    public class MarketQuotes
    {
        public MarketIndex DOW { get; set; }
        public MarketIndex NASDAQ { get; set; }
        public MarketIndex SP500 { get; set; }
        public List<DataPoint> DOWDataPoints { get; set; }
        public List<DataPoint> NASDAQDataPoints { get; set; }
        public List<DataPoint> SP500DataPoints { get; set; } 
    }
}
