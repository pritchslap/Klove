using System;
using System.Collections.Generic;

namespace KloveApp.Models
{
    public class ManageDepartmentModel
    {
        public ManageDepartmentModel()
        {
            ExternalEmployees = new List<EmployeeModel>();
            InternalEmployees = new List<EmployeeModel>();
        }

        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public IList<EmployeeModel> ExternalEmployees { get; set; }

        public IList<EmployeeModel> InternalEmployees { get; set; }
    }
}