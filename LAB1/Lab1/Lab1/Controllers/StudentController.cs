using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        public ViewResult display()
        {
            return View();
        }
        public ViewResult showadd()
        {
            return View();
        }
        public IActionResult register()
        {
            return View("register");
        }
        public IActionResult details(UserModel user)
        {
            if (user.Image != null && user.Image.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs");
                string uniqueFileName = Path.GetFileName(user.Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    user.Image.CopyTo(fileStream);
                }
                ViewBag.img = "/imgs/" + uniqueFileName;
            }
            ViewBag.Username = user.UserName;
            ViewBag.Email = user.Email;
            ViewBag.Gender = user.Gender;
            ViewBag.Password = "********";
            return View("details");
        }
        public ViewResult add(int x,int y)
        {
            x=Convert.ToInt32(Request.Form["x"]);
            y = Convert.ToInt32(Request.Form["y"]);
            ViewBag.sum = x + y;
            return View();
        }
        public ViewResult divide (int x,int y)
        {
            x = Convert.ToInt32(Request.Form["x"]);
            y = Convert.ToInt32(Request.Form["y"]);

            return View();
        }
        [HttpPost]
        [Route("student/procces")]
        public IActionResult procces(int x, int y,string operation)
        {
            x = Convert.ToInt32(Request.Form["x"]);
            y = Convert.ToInt32(Request.Form["y"]);
            if (operation == "add")
            {
                int sum = x + y;
                ViewBag.sum = sum;
                return View("add");
            }
            else if (operation == "divide")
            {
                if (y == 0)
                {
                    ViewBag.error= "cannot divide by zero"; 
                }
                else
                {
                    int divide = x / y;
                    ViewBag.divide = divide;
                    return View("divide");
                }
            }

                return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
