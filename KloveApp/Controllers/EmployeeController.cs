using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using KloveApp.Models;

namespace KloveApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            KloveEntities data = new KloveEntities();
            ICollection<EmployeeModel> employees = new List<EmployeeModel>();
            var emplist = data.Employees.ToList();

            foreach (Employee emp in emplist)
            {
                EmployeeModel employee = new EmployeeModel();
                employee.Id = emp.Id;
                employee.DepartmentId = emp.DepartmentId;
                employee.Name = emp.Name;
                employee.EmployeeNumber = emp.EmployeeNumber;

                employees.Add(employee);
            }
            return View(employees);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            try
            {
                KloveEntities data = new KloveEntities();
                Employee emp = new Employee();
                emp.Id = Guid.NewGuid();
                emp.EmployeeNumber = employee.EmployeeNumber;
                emp.Name = employee.Name;

                data.Employees.Add(emp);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(Guid id)
        {
            KloveEntities data = new KloveEntities();
            Employee emp = data.Employees.Single(x => x.Id == id);
            EmployeeModel employee = new EmployeeModel();
            if (emp != null)
            {
                employee.Id = emp.Id;
                employee.DepartmentId = emp.DepartmentId;
                employee.EmployeeNumber = emp.EmployeeNumber;
                employee.Name = emp.Name;
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            try
            {
                KloveEntities data = new KloveEntities();
                Employee emp = new Employee();
                emp.Id = employee.Id;
                emp.DepartmentId = employee.DepartmentId;
                emp.Name = employee.Name;
                emp.EmployeeNumber = employee.EmployeeNumber;
                data.Employees.AddOrUpdate(emp);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(Guid id)
        {
            KloveEntities data = new KloveEntities();
            Employee emp = data.Employees.Single(x => x.Id == id);
            if (emp != null)
            {
                data.Employees.Remove(emp);
                data.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
