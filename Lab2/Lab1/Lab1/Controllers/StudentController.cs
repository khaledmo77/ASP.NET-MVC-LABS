using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Reflection;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationContext _context;
        public StudentController(ApplicationContext context)
        {
            _context = context;
        }
        public ViewResult display()
        {
            return View();
        }
        public ViewResult showadd()
        {
            return View();
        }
        public IActionResult register(int? id)
        {

            var model = new UserModel()
            {
                Depts = _context.Departments.ToList()
            };
            return View("register", model);
        }
        public IActionResult Edit (int? id)
        {
            if (!id.HasValue) return BadRequest("User ID is required.");

            var user = _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Gender = u.Gender,
                    Password=u.Password,
                    DepartmentId = u.DepartmentId,
                    Depts = _context.Departments.ToList(),
                    ImageData = u.ImageData
                })
                .FirstOrDefault();
            if (user == null) return NotFound("User not found.");
            return View("register",user);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("showAll"); // Redirect after deletion
        }

        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            if (user == null) return BadRequest("User data is required.");
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser == null) return NotFound("User not found.");
            if (user.DepartmentId != null)
            {
                user.Department = _context.Departments.FirstOrDefault(d => d.deptid == user.DepartmentId);
            }
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.Gender = user.Gender;
            existingUser.Password = user.Password;
            existingUser.DepartmentId = user.DepartmentId;


            if (user.Image != null && user.Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    user.Image.CopyTo(memoryStream);
                    existingUser.ImageData = memoryStream.ToArray();
                }
            }
            _context.Users.Update(existingUser);
            _context.SaveChanges();
            return RedirectToAction("showAll");
        }
        //  public IActionResult register(int? id)
        //{
        //    UserModel model;
        //    if (id.HasValue)
        //    {
        //        model = _context.Users
        //            .Where(u => u.Id == id)
        //            .Select(u => new UserModel
        //        {
        //            Id = u.Id,
        //            UserName=u.UserName,
        //            Email=u.Email,
        //            Gender=u.Gender,
        //            DepartmentId=u.DepartmentId,
        //            Depts=_context.Departments.ToList(),
        //               ImageData  = u.ImageData

        //            }).FirstOrDefault();
        //        if (model == null)
        //        {
        //            return NotFound("User not found");
        //        }

        //    }
        //    else 
        //    {
        //        model = new UserModel
        //        {
        //            Depts = _context.Departments.ToList()
        //        };
        //    }
        //    //var model = new UserModel()
        //    //{
        //    //    Depts = _context.Departments.ToList()
        //    //};
        //    return View("register", model);
        //}
        [HttpPost]
        public IActionResult register(UserModel user)
        {
            if (user == null)
            {
                return BadRequest("User data is required"); 
            }
            if (user.DepartmentId != null)
            {
                user.Department = _context.Departments.FirstOrDefault(d => d.deptid == user.DepartmentId);
            }

            if (user.Image!=null&& user.Image.Length > 0)
            {
                using(var memoryStream=new MemoryStream())
                {
                    user.Image.CopyTo(memoryStream);
                    user.ImageData = memoryStream.ToArray();
                }

                _context.Users.Add(user);
            }


      
  
            _context.SaveChanges();

            return RedirectToAction("showAll");
        
        }
        public IActionResult showAll()
        {
            var users = _context.Users
                .Include(u => u.Department) 
                .ToList();

            return View(users);
        }


        //public async Task<IActionResult> details(UserModel user)
        //{
        //    if (user.Image != null && user.Image.Length > 0)
        //    {
        //        using (var MemoryStream = new MemoryStream())
        //        {
        //            await user.Image.CopyToAsync(MemoryStream);
        //            user.ImageData = MemoryStream.ToArray();
        //        }
        //    }
        //    ViewBag.Username = user.UserName;
        //    ViewBag.Email = user.Email;
        //    ViewBag.Gender = user.Gender;
        //    ViewBag.Password = "********";
        //    return View("details");
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
