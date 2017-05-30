using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace edX.DataApp.CoreConsole
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool? SafetyReviewResult { get; set; }

        public Guid ExternalId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
