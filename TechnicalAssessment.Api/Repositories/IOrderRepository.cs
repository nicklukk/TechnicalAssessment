using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(ApiModels.MakeOrderModel makeOrderModel, CancellationToken cancelationToken);

        Task<List<Order>> GetAsync(Guid? userId, CancellationToken cancellationToken);
    }
}
