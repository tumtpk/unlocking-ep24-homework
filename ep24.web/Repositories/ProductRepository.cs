using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ep24.web.Models;

namespace ep24.web.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product data);
        void CreateNewProduct(Product data);
    }
}