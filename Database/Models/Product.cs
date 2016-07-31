namespace Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product : Entity
    {
        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
    }
}
