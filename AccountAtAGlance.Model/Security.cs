using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AccountAtAGlance.Model
{
    //Attributes added in case Web API is called
    //with client wanting XML
    [KnownType(typeof(Stock))]
    [KnownType(typeof(MutualFund))]
    public abstract class Security
    {
        // Primitive properties
        public int Id { get; set; }
        public decimal Change { get; set; }
        public decimal PercentChange { get; set; }
        public decimal Last { get; set; }
        public decimal Shares { get; set; }
        [StringLength(5)]
        public string Symbol { get; set; }
        public System.DateTime RetrievalDateTime { get; set; }
        [StringLength(100)]
        public string Company { get; set; }

        // Additional properties, not in the DB
        public List<DataPoint> DataPoints { get; set; }    
    }
}
