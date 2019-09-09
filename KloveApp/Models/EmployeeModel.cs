using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;

namespace KloveApp.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? DepartmentId { get; set; }

        [Display(Name="Employee Number")]
        public string EmployeeNumber { get; set; }
    }
}