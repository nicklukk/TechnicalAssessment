using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;
using TechnicalAssessment.Api.Repositories;

namespace TechnicalAssessment.Api.BL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderLineRepository orderLineRepository;

        public OrderService(IOrderRepository orderRepository, IOrderLineRepository orderLineRepository)
        {
            this.orderRepository = orderRepository;
            this.orderLineRepository = orderLineRepository;
        }

        public async Task MakeOrder(ApiModels.MakeOrderModel model, CancellationToken cancelationToken)
        {
            var order = await orderRepository.CreateAsync(model, cancelationToken);

            await orderLineRepository.BulkCreateAsync(model.OrderLines, order.Id, cancelationToken);
        }

        public async Task<List<Order>> GetOrdersAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAsync(userId, cancellationToken);

            return orders;
        }
    }
}
