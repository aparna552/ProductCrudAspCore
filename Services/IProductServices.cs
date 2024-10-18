using ProductManagement.Models;

namespace ProductManagement.Services
{
    public interface IProductServices
    {
        public List<Product> GetProductsList();
        public string insertproduct(Product product);
        public string updateproduct(Product product);
        public string deleteproduct(int productid);

        public bool TestDatabaseConnection();


    }
}
