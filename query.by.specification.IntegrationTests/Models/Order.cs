using System.Collections.Generic;

namespace query.@by.specification.IntegrationTests.Models
{
    public partial class Order
    {
        public Order()
        {
            this.LineItems = new List<LineItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string StoreName { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
