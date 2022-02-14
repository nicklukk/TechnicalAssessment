using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.BL
{
    public interface IOrderService
    {
        Task MakeOrder(ApiModels.MakeOrderModel model, CancellationToken cancelationToken);
        Task<List<Order>> GetOrdersAsync(Guid? userId, CancellationToken cancellationToken);
    }
}
