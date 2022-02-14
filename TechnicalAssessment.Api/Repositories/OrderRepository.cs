using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ITechnicalAssessmentContext technicalAssessmentContext;

        public OrderRepository(ITechnicalAssessmentContext technicalAssessmentContext)
        {
            this.technicalAssessmentContext = technicalAssessmentContext;
        }

        public async Task<Order> CreateAsync(ApiModels.MakeOrderModel makeOrderModel, CancellationToken cancelationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = makeOrderModel.OrderNumber,
                OrderDate = DateTime.UtcNow,
                Reference = makeOrderModel.Reference,
                CustomerName = makeOrderModel.CustomerName,
                UserId = makeOrderModel.UserId
            };

            await technicalAssessmentContext.Orders.AddAsync(order, cancelationToken);
            await technicalAssessmentContext.SaveChangesAsync(cancelationToken);

            return order;
        }

        public async Task<List<Order>> GetAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var orders = userId.HasValue 
                ? technicalAssessmentContext.Orders.Where(x => x.UserId == userId.Value) 
                : technicalAssessmentContext.Orders;
            return await orders
                .Include(x => x.OrderLines)
                .ToListAsync(cancellationToken);
        }
    }
}
