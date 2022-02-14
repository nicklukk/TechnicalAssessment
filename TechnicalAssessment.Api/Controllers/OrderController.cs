using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.ApiModels;
using TechnicalAssessment.Api.BL;


namespace TechnicalAssessment.Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("make")]
        public async Task<OkResult> MakeOrder([FromBody] MakeOrderModel model, CancellationToken cancelationToken)
        {
            await orderService.MakeOrder(model, cancelationToken);

            return Ok();
        }

        [HttpGet("all")]
        public async Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken)
        {
            var orders = await orderService.GetOrdersAsync(null, cancellationToken);

            return MapOrders(orders);
        }

        [HttpGet("{userId}")]
        public async Task<List<Order>> GetOrdersAsync(Guid userId, CancellationToken cancellationToken)
        {
            var orders = await orderService.GetOrdersAsync(userId, cancellationToken);

            return MapOrders(orders);
        }

        private static List<Order> MapOrders(List<Models.Order> orders)
        {
            return orders.Select(x => new Order
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                OrderDate = x.OrderDate,
                Reference = x.Reference,
                CustomerName = x.CustomerName,
                UserId = x.UserId,
                OrderLines = x.OrderLines.Select(y => new OrderLine
                {
                    Id = y.Id,
                    LineNumber = y.LineNumber,
                    ItemCode = y.ItemCode,
                    Quantity = y.Quantity,
                    Price = y.Price
                }).ToList()
            }).ToList();
        }
    }
}
