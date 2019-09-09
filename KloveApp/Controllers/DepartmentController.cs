using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KloveApp.Models;

namespace KloveApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            KloveEntities data = new KloveEntities();
            var items = data.Departments.ToList();
            ICollection<DepartmentModel> departments = new List<DepartmentModel>();
            foreach (var item in items)
            {
                DepartmentModel dept = new DepartmentModel();
                dept.Id = item.Id;
                dept.Name = item.Name;
                dept.DepartmentNumber = item.DepartmentNumber;
                departments.Add(dept);
            }

            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(DepartmentModel department)
        {
            try
            {
                KloveEntities data = new KloveEntities();
                Department dept = new Department();
                dept.Id = Guid.NewGuid();
                dept.Name = department.Name;
                dept.DepartmentNumber = department.DepartmentNumber;
                data.Departments.Add(dept);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(Guid id)
        {
            KloveEntities data = new KloveEntities();
            Department dept = data.Departments.Single(x => x.Id == id);
            DepartmentModel department = new DepartmentModel();
            department.Id = dept.Id;
            department.DepartmentNumber = dept.DepartmentNumber;
            department.Name = dept.Name;
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(DepartmentModel department)
        {
            try
            {
                KloveEntities data = new KloveEntities();
                Department dept = new Department();
                dept.Id = department.Id;
                dept.Name = department.Name;
                dept.DepartmentNumber = department.DepartmentNumber;
                data.Departments.AddOrUpdate(dept);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ManageDepartment(Guid id)
        {
            ManageDepartmentModel model = new ManageDepartmentModel();
            model.DepartmentId = id;

            KloveEntities data = new KloveEntities();
            Department department = data.Departments.Single(x => x.Id == id);
            if (department != null)
            {
                model.DepartmentName = department.Name;
            }
            var employees = data.Employees.ToList();

            foreach (var emp in employees)
            {
                EmployeeModel employee = new EmployeeModel();
                employee.Id = emp.Id;
                employee.DepartmentId = emp.DepartmentId;
                employee.Name = emp.Name;
                employee.EmployeeNumber = emp.EmployeeNumber;

                if (employee.DepartmentId == id)
                {
                    model.InternalEmployees.Add(employee);
                }
                else
                {
                    model.ExternalEmployees.Add(employee);
                }
            }
            return View(model);
        }

        public ActionResult AddEmployee(Guid deptId, Guid empId)
        {
            KloveEntities data = new KloveEntities();
            Employee emp = data.Employees.Single(x => x.Id == empId);
            if (emp != null)
            {
                emp.DepartmentId = deptId;
                data.SaveChanges();
            }
            return RedirectToAction("ManageDepartment", new {id = deptId});
        }

        public ActionResult RemoveEmployee(Guid deptId, Guid empId)
        {
            KloveEntities data = new KloveEntities();
            Employee emp = data.Employees.Single(x => x.Id == empId);
            if (emp != null)
            {
                emp.DepartmentId = null;
                data.SaveChanges();
            }
            return RedirectToAction("ManageDepartment", new {id = deptId});
        }

        // GET: Department/Delete/5
        public ActionResult Delete(Guid id)
        {
            KloveEntities data = new KloveEntities();
            Department dept = data.Departments.Single(x => x.Id == id);
            if (dept != null)
            {
                data.Departments.Remove(dept);
            }
            return RedirectToAction("Index");
        }
    }
}
