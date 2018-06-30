using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ep24.web.Models;

namespace ep24.web.Repositories
{
    public interface IOrderRepository
    {
        Order Get(Expression<Func<Order, bool>> expression);
        IEnumerable<Order> List(Expression<Func<Order, bool>> expression);
        void Create(Order document);
        void Update(Order document);
    }
}