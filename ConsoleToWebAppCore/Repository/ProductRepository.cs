using ConsoleToWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAppCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModel> products = new List<ProductModel>();
        public int AddProduct(ProductModel model)
        {
            model.Id = products.Count + 1;
            products.Add(model);
            return model.Id;
        }

        public string GetName()
        {
            return "This is from Product Repository";
        }

        public List<ProductModel> GetProducts()
        {
            return products.ToList();
        }
    }
}
