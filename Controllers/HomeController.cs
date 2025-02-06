using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.DBConnection;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        newBatch10Entities obj = new newBatch10Entities();
        public ActionResult Index()
        {
            var res = obj.Employees.ToList();
          List<EmpModel> list = new List<EmpModel>();

            foreach (var emp in res) {
                list.Add (new EmpModel()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email= emp.Email,
                    MobileNo= emp.MobileNo,
                    Address= emp.Address,

                });
            }

         return View(list);
        }
        [HttpGet]
        public ActionResult CreateEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmp(EmpModel obj1)
        {
            Employee emp = new Employee();
            emp.Id= obj1.Id;
            emp.Name= obj1.Name;
            emp.Email= obj1.Email;
            emp.MobileNo= obj1.MobileNo;
            emp.Address= obj1.Address;

            obj.Employees.Add(emp);
            obj.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var data = obj.Employees.Where(a => a.Id == Id).FirstOrDefault();
            EmpModel emp = new EmpModel();
            emp.Id= data.Id;
            emp.Name= data.Name;
            emp.Email= data.Email;
            emp.MobileNo= data.MobileNo;
            emp.Address= data.Address;
            return View("CreateEmp", emp);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Delete(int Id)
        {
            var data = obj.Employees.Where(a => a.Id == Id).FirstOrDefault();
            obj.Employees.Remove(data);
            obj.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}