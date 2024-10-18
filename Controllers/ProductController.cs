using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductServices _productservices;
        public ProductController(IConfiguration configuration, IProductServices productservices)
        {
            _configuration = configuration;
            _productservices = productservices;
        }

      

      
        public IActionResult Index()
        {
           
            ProductVM model = new ProductVM();
            bool isConnected = _productservices.TestDatabaseConnection();
            ViewBag.DbConnectionStatus = isConnected ? "Database connection is successful." : "Database connection failed.";

            model.productsList = _productservices.GetProductsList().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddUpdateProduct(Product product)
        {
            ProductVM model= new ProductVM();
            string url = Request.Headers["Referer"].ToString();
            string result=string.Empty;
            if(product.productid>0)
            {
                result = _productservices.updateproduct(product);
            }
            else
            {
                result=_productservices.insertproduct(product);
            }
            if (result == "Save Successfully")
            {
                TempData["Successmsg"] = "Save Successfully";
                return Redirect(url);
            }
            else
            {
                TempData["Errormsg"] = result;
                return Redirect(url);
            }

          
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productid)
        {
            string url= Request.Headers["Referer"].ToString();
            string result = _productservices.deleteproduct(productid);
            if (result== "Delete Sucessfully")
            {
                return Json(new { message = "Delete Sucessfully" });
            }
            else
            {
                return Json(new { message = "Error Occured" });
            }


        }


    }
}
