using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCore_webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCore_webapp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly CompanyDBContext _context;

        public EmployeeController(CompanyDBContext context)
        {
            _context = context;
        }


        // GET: EmployeeController
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            //var emp = await _context.empdup.ToListAsync();

            var employee = await _context.Employees.ToListAsync();

            return View(employee);
        }

    
        // GET: EmployeeController/Create
        public async Task< IActionResult> CreateorEdit(int? employeeId)
        {

           List<Employees> ListEmp = await _context.Employees.ToListAsync();

            Employees employee = new Employees()
            {
                EmpList = new List<EmployeeList>()
            };

            List<EmployeeList> EmployeeList = ListEmp.Select(e => new EmployeeList
            {
                EmployeeListId = e.EmployeeId,
                Name = e.Name,
                Address = e.Address,
                Designation = e.Designation,
                Salary = e.Salary,
                JoiningDate = e.JoiningDate
            }).ToList();

            // Add individual EmployeeList objects to employee.EmpList
            employee.EmpList.AddRange(EmployeeList);


            ViewBag.PageName = employeeId == null ? "Create Employee" : "Edit Employee";
            ViewBag.IsEdit = employeeId == null ? false : true;

            if (employeeId == null)
            {
                //employee = await _context.Employees.FindAsync(1);
                //if (employee.EmpList == null)
                //{
                //    employee.EmpList = new List<EmployeeList>();
                //}
                //employee.EmpList.AddRange(EmployeeList);
                return View(employee);
            }
            else
            {
                Employees emp = await _context.Employees.FindAsync(employeeId);

                if (emp == null)
                {
                    return NotFound();
                }
                // Initialize emp.EmpList if it's null
                if (emp.EmpList == null)
                {
                    emp.EmpList = new List<EmployeeList>();
                }

                emp.EmpList.AddRange(EmployeeList);
                return View(emp);
               
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateorEdit(int employeeid, Employees employeedata)
        {

            bool IsEmployeeExist = false;
            Employees emp = await _context.Employees.FindAsync(employeeid);

            try
            {
                if (ModelState.IsValid == true)
                {
                    if (emp != null)
                    {
                        IsEmployeeExist = true;
                    }
                    //else
                    //{
                    //    employee = new Employee();
                    //}

                    if (IsEmployeeExist)
                    {
                        emp.Name = employeedata.Name;
                        emp.Address = employeedata.Address;
                        emp.Salary = employeedata.Salary;
                        emp.Designation = employeedata.Designation;
                        emp.JoiningDate = employeedata.JoiningDate;

                        _context.Employees.Update(emp);
                      
                    }

                    else
                    {
                        _context.Employees.Add(employeedata);
                        
                    }
                    await _context.SaveChangesAsync();


                    List<Employees> ListEmp = await _context.Employees.ToListAsync();

                    Employees employee = new Employees()
                    {
                        EmpList = new List<EmployeeList>()
                    };

                    List<EmployeeList> EmployeeList = ListEmp.Select(e => new EmployeeList
                    {
                        EmployeeListId = e.EmployeeId,
                        Name = e.Name,
                        Address = e.Address,
                        Designation = e.Designation,
                        Salary = e.Salary,
                        JoiningDate = e.JoiningDate
                    }).ToList();

                    employee.EmpList.AddRange(EmployeeList);


                    return View(employee);
                }

            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return View(employeedata);
        }

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            _context.Remove(data);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }

        //// POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
    }
}
