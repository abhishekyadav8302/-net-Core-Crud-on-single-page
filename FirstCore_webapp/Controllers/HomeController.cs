using FirstCore_webapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCore_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
        //    List<Employee> Employees = new List<Employee>
        //{
        //    new Employee{Id=1,Name="Abhi",DeptId=1},
        //    new Employee{Id=2,Name="Dk",DeptId=2},
        //    new Employee{Id=3,Name="Ar",DeptId=3},
        //    new Employee{Id=4,Name="Rk",DeptId=4}

        //};
        //    List<EmpDepartment> Department = new List<EmpDepartment>
        //{
        //    new EmpDepartment{DeptId=1,Department= ".Net Developer"},
        //    new EmpDepartment{DeptId=2,Department="Designer"},
        //    new EmpDepartment{DeptId=3,Department="Android"},
        //    new EmpDepartment{DeptId=4,Department= "Sales"}

        //};

        //    var result = from emp in Employees
        //                 join dep in Department
        //                 on emp.DeptId equals dep.DeptId
        //                 select new EmpDetails
        //                 {
        //                     Id = emp.Id,
        //                     Name = emp.Name,
        //                     Department = dep.Department
        //                 };

        //    HttpContext.Session.SetString("EmpName", result.ElementAt(0).Name);

        //    ViewBag.Name = HttpContext.Session.GetString("EmpName");
            return View();
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
