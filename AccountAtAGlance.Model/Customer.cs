using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountAtAGlance.Model
{
    public class Customer
    {
        public Customer()
        {
            BrokerageAccounts = new HashSet<BrokerageAccount>();
        }
    
        // Primitive properties
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        public int Zip { get; set; }
        [StringLength(10)]
        public string CustomerCode { get; set; }
        public string NewPropertyAdded { get; set; }
    
        // Navigation properties
        public ICollection<BrokerageAccount> BrokerageAccounts { get; set; }
    }
}
