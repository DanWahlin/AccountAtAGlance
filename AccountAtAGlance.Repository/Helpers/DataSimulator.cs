using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository.Helpers
{
    public class DataSimulator
    {
        //Simulate daily fluctuations in security pricing
        public List<DataPoint> GetDataPoints(decimal last)
        {
            var low = last - (last * .1M);
            var high = last + (last * .1M);
            var now = DateTime.Now;            
            var open = new DateTime(now.Year, now.Month, now.Day, 9, 30, 0);  //Market open
            var close = new DateTime(now.Year, now.Month, now.Day, 16, 0, 0); //Market close
            if (now.Hour < open.Hour) now = close;
            var currTime = open;
            var dataPoints = new List<DataPoint>();

            if (now.Hour < close.Hour)
            {
                //Cut-off fake data points at current hour since we're in the middle of the trading day
                close = new DateTime(1, 1, 1, now.Hour + 1, 0, 0);
            }


            while (currTime.TimeOfDay <= close.TimeOfDay)
            {
                var r = new Random((int)currTime.Ticks);
                decimal val = (decimal)(r.Next((int)low, (int)high) + Math.Round(r.NextDouble(), 2)); //Simulate a price change
                dataPoints.Add(new DataPoint
                {
                    JSTicks = GetJavascriptTimestamp(currTime),
                    Value = (currTime.TimeOfDay == close.TimeOfDay)?last:val,
                    Time = currTime.TimeOfDay.ToString()
                });
                currTime = currTime.AddMinutes(30); //Create a data point every 30 minutes
            }
            return dataPoints;
        }

        public long GetJavascriptTimestamp(System.DateTime input)
        {
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = input.Subtract(span);
            return (long)(time.Ticks / 10000);
        }
    }
}
