namespace AccountAtAGlance.Model
{
    public class Order
    {
        // Primitive properties
        public int Id { get; set; }
        public decimal NumberOfShares { get; set; }
        public decimal Price { get; set; }
        public int OrderTypeId { get; set; }
        public int SecurityId { get; set; }
        public int BrokerageAccountId { get; set; } // New
    
        // Navigation properties
        public virtual BrokerageAccount BrokerageAccount { get; set; }  
        public virtual Security Security { get; set; }
        public virtual OrderType OrderType { get; set; }
    }
}
