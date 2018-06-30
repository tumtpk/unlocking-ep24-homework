using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Collections;
using Moq;
using Xunit;
using ep24.web.Models;
using ep24.web.Repositories;
using ep24.web.Controllers;

namespace ep24.web.tests
{
    public class ListHistory
    {
        [Fact(DisplayName = "ขอรายการสั่งซื้อจากรหัสอ้างอิง")]
        public void ListOrderHistoryTest()
        {
            var mock = new MockRepository(MockBehavior.Default);
            var repoProduct = mock.Create<IProductRepository>();
            var repoOrder = mock.Create<IOrderRepository>();
            var api = new OrderController(repoProduct.Object, repoOrder.Object);
            var allOrders = new List<Order>
            {
                new Order{ OrderDate = new DateTime(2018, 6, 26), PaidDate = new DateTime(2018, 6, 26), },
                new Order{ OrderDate = new DateTime(2018, 6, 27), PaidDate = new DateTime(2018, 6, 27), },
                new Order{ OrderDate = new DateTime(2018, 6, 28), PaidDate = new DateTime(2018, 6, 28), },
                new Order{ OrderDate = new DateTime(2018, 6, 29), },
                new Order{ OrderDate = new DateTime(2018, 6, 30), },
            };
            repoOrder.Setup(it => it.List(It.IsAny<Expression<Func<Order, bool>>>()))
                .Returns<Expression<Func<Order, bool>>>((expression) => allOrders.Where(expression.Compile()).ToList());

            var response = api.ListHistory();

            response.Should().BeEquivalentTo(new List<Order>
            {
                new Order{ OrderDate = new DateTime(2018, 6, 26), PaidDate = new DateTime(2018, 6, 26), },
                new Order{ OrderDate = new DateTime(2018, 6, 27), PaidDate = new DateTime(2018, 6, 27), },
                new Order{ OrderDate = new DateTime(2018, 6, 28), PaidDate = new DateTime(2018, 6, 28), },
            });
            repoProduct.VerifyNoOtherCalls();
            repoOrder.Verify(dac => dac.List(It.IsAny<Expression<Func<Order, bool>>>()), Times.Once);
            repoOrder.VerifyNoOtherCalls();
        }
    }
}
