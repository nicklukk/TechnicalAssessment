﻿namespace TechnicalAssessment.Api.ApiModels
{
    public class AddOrderLineModel
    {
        public int? LineNumber { get; set; }

        public string ItemCode { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
