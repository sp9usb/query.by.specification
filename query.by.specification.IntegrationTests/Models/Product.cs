using System.Collections.Generic;

namespace query.@by.specification.IntegrationTests.Models
{
    public partial class Product
    {
        public Product()
        {
            this.LineItems = new List<LineItem>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
