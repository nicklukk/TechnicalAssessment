using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssessment.Api.Models
{
    public class OrderLine
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        
        public virtual Order Order { get; set; }

        public int? LineNumber { get; set; }

        public string ItemCode { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,9)")]
        public decimal Price { get; set; }
    }
}
