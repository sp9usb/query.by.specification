using System;
using System.Collections.Generic;

namespace query.by.specification.Tests.Models
{
    public partial class LineItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quatity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
