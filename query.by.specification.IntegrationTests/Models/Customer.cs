using System.Collections.Generic;

namespace query.@by.specification.IntegrationTests.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Addresses = new List<Address>();
            //this.Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
