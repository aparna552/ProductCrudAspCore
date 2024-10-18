using Dapper;
using ProductManagement.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductManagement.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IConfiguration _configuration;
        public string connectionstring { get; }

        public string providername { get; }
        public ProductServices(IConfiguration configuration)
        {


            connectionstring = configuration.GetConnectionString("conn");
            providername = "System.Data.client";
        }



        
        public IDbConnection connection => new SqlConnection(connectionstring);

        public string deleteproduct(int productid)
        {

            string result = "";
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    dbConnection.Open();
                  
                    var stdnt = dbConnection.Query<Product>("deleteproduct",
                        new { productid=productid }, commandType: CommandType.StoredProcedure);


                    if (stdnt != null)
                    {
                        result = "Delete Sucessfully";



                    }

                    dbConnection.Close();
                    return result;


                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error :" + ex.Message);
            }
            return result;
        }

        public List<Product> GetProductsList()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    dbConnection.Open();
                    
                    products = dbConnection.Query<Product>("getproduct", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return products;
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error fetching products:"+ ex.Message);
            }

            return products; 
        }

        public string insertproduct(Product product)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    dbConnection.Open();
                    
                   var stdnt = dbConnection.Query<Product>("insertProduct",
                       new { productname=product.productname, description=product.description } ,commandType: CommandType.StoredProcedure);
                    
                    if (stdnt != null )
                    {
                        result = "Save Sucessfully";
                    }
                   dbConnection.Close();
                 
                    
                }
            }
            catch (Exception ex)
            {
                // Log the error message for debugging
                Console.WriteLine("Error :" + ex.Message);
            }
            return result;



        }

        public string updateproduct(Product product)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    dbConnection.Open();
                    // Query the stored procedure to insert products
                    var stdnt = dbConnection.Query<Product>("updateproduct",
                        new { productname = product.productname, description = product.description,productid=product.productid }, commandType: CommandType.StoredProcedure);
                    
                    if (stdnt != null)
                    {
                        result = "Save Sucessfully";
                    }
                    dbConnection.Close();
                    

                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error fetching products:" + ex.Message);
            }
            return result;
        }

        public bool TestDatabaseConnection()
        {
            try
            {
                using (IDbConnection dbConnection = connection)
                {
                    dbConnection.Open(); 
                    return dbConnection.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false; 
            }
        }

    }
}
