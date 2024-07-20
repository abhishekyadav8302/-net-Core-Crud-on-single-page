using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstCore_webapp.Models
{
    //public partial class Employees
    //{
    //    public int EmployeeId { get; set; }
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //    public string Designation { get; set; }
    //    public decimal? Salary { get; set; }
    //    public DateTime? JoiningDate { get; set; }
    //}

    public partial class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        public List<EmployeeList> EmpList { get; set; }

    }
    public class EmployeeList
    {
        public int EmployeeListId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }

    }



}
