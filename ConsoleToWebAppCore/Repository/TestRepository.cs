using ConsoleToWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Repository
{
    public class TestRepository : IProductRepository
    {
        public int AddProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "This is from Test Repository";
        }

        public List<ProductModel> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
