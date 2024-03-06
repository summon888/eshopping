using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded");
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
        {
            new()
            {
                UserName = "yaki",
                FirstName = "Yaki",
                LastName = "Nguyen",
                EmailAddress = "yakinguyen@eshop.net",
                AddressLine = "HCM City",
                Country = "VietNam",
                TotalPrice = 750,
                State = "VN",
                ZipCode = "700000",

                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "Yaki",
                Expiration = "12/25",
                Cvv = "123",
                PaymentMethod = 1,
                LastModifiedBy = "Yaki",
                LastModifiedDate = new DateTime(),
            }
        };
        }
    }
}
