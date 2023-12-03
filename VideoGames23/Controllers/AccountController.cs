using Microsoft.AspNetCore.Mvc;
using VideoGames23.Models;

namespace VideoGames23.Controllers
{
    public class AccountController : Controller
    {
        private static List<LoginModel> users = new List<LoginModel>();

        [HttpGet]
        public IActionResult Login()
        {
            return View(users);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = users.Count + 1;
                users.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = users.FirstOrDefault(u => u.Id == model.Id);

                if (existingUser != null)
                {
                    existingUser.Username = model.Username;
                    existingUser.Password = model.Password;
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                return View("SearchResult", user);
            }
            else
            {
                ViewBag.ErrorMessage = "User not found!";
                return View();
            }
        }

        /*[HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Validate the login credentials here (e.g., check against a database)
                // For simplicity, let's assume a successful login for any non-empty credentials
                if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
                {
                    // Redirect to a dashboard or another page on successful login
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials. Please try again.");
                }
            }
            // If the model is not valid, return to the login page with validation errors
            return View(model);
        }
        
    }*/
    }
}
