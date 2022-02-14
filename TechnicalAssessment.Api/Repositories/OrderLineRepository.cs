using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Repositories
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly ITechnicalAssessmentContext technicalAssessmentContext;

        public OrderLineRepository(ITechnicalAssessmentContext technicalAssessmentContext)
        {
            this.technicalAssessmentContext = technicalAssessmentContext;
        }

        public async Task<List<OrderLine>> BulkCreateAsync(List<ApiModels.AddOrderLineModel> orderLines, Guid orderId, CancellationToken cancelationToken)
        {
            var orderLinesToCreate = orderLines.Select(x => new OrderLine
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                LineNumber = x.LineNumber,
                ItemCode = x.ItemCode,
                Quantity = x.Quantity,
                Price = x.Price
            }).ToList();

            await technicalAssessmentContext.OrderLines.AddRangeAsync(orderLinesToCreate, cancelationToken);
            await technicalAssessmentContext.SaveChangesAsync(cancelationToken);

            return orderLinesToCreate;
        }
    }
}
