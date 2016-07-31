namespace Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOption")]
    public partial class ProductOption : Entity
    {
        public Guid ProductId { get; set; }
    }
}
