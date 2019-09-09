using System;
using System.ComponentModel.DataAnnotations;

namespace KloveApp.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        [Display(Name = "Department Number")]
        public string DepartmentNumber { get; set; }
    }
}