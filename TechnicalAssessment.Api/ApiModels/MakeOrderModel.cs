using System;
using System.Collections.Generic;

namespace TechnicalAssessment.Api.ApiModels
{
    public class MakeOrderModel
    {
        public int? OrderNumber { get; set; }

        public string Reference { get; set; }

        public string CustomerName { get; set; }

        public Guid UserId { get; set; }

        public virtual List<AddOrderLineModel> OrderLines { get; set; }
    }
}
