using System;
using System.Collections.Generic;

namespace TechnicalAssessment.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public int? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public string Reference { get; set; }

        public string CustomerName { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
