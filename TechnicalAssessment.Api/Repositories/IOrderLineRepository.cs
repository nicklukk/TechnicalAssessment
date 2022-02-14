using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Repositories
{
    public interface IOrderLineRepository
    {
        Task<List<OrderLine>> BulkCreateAsync(List<ApiModels.AddOrderLineModel> orderLines, Guid orderId, CancellationToken cancelationToken);
    }
}
