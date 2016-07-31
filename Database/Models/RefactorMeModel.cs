namespace Database.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Configuration;

    public partial class RefactorMeModel : DbContext
    {
        public RefactorMeModel()
            : base("name=RefactorMeModel")
        {
            var dbPath = ConfigurationManager.AppSettings["DbPath"];
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
