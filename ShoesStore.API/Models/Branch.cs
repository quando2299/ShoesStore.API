using System;
using System.Collections.Generic;

#nullable disable

namespace ShoesStore.API.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
