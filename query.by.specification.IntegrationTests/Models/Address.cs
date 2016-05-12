using System;
using System.Collections.Generic;

namespace query.by.specification.Tests.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public int Postcode { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
