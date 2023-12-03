using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using VideoGames23.Models;

namespace VideoGames23.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();

        List<Product> products = new List<Product>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = VideoGames23.Properties.Resources.ConnectionString;
        }

        public IActionResult Index() { 
            return View();
        }

        


        public void FetchData()
        {
            if (products.Count > 0)
            {
                products.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Products";
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    /*products.Add(new Product()
                    {
                        ProductID = dr["ProductID"].ToString(),
                        ProductName = dr["ProductName"].ToString(),
                        Description = dr["Describe"].ToString(),
                        Price = dr["Price"].ToString(),
                        Category = dr["Category"].ToString(),
                        System = dr["Console"].ToString()
                    });*/
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        public ViewResult VideoGameForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult VideoGameForm(Product product)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(product);
                return View("VideoGameThanks", product);
            }
            else
            {
                return View();
            }            
        }
        public ViewResult VideoGameList()
        {
            return View(Repository.Response);
        }

        public ViewResult VideoGameDelete()
        {
            return View(Repository.Response);
        }

        public ViewResult VideoGameEdit()
        {
            return View(Repository.Response);
        }

        public ViewResult VideoGameDetails(int id)
        {
            //if (id == 0)
            //{
            //    return NotFound();
            //}
            //Product product = Models.Product.SingleOrDefault(x => x.ProductID == id);
            //if(product == null)
            //{
            //    return NotFound();
            //}
            return View(Repository.Response);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}