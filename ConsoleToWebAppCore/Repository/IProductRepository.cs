using ConsoleToWebAppCore.Models;
using System.Collections.Generic;

namespace ConsoleToWebAppCore.Repository
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel model);
        List<ProductModel> GetProducts();

        string GetName();
    }
}