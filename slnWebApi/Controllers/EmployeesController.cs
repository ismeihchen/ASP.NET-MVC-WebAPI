using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using slnWebApi.Models;

namespace slnWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: api/Employee       
        public List<EmployeeList> Get()
        {
            var q = from a in db.tEmployee
                   join p in db.tDepartment on a.fDepId equals p.fDepId 
                   select new
                   {
                       fEmpId = a.fEmpId,
                       fDepId = a.fDepId,
                       fName = a.fName,
                       fPhone = a.fPhone,                  
                       fDepName = p.fDepName
                   };

            var employee = new List<EmployeeList>();
            foreach (var item in q)
            {
                employee.Add(new EmployeeList()
                {
                    fEmpId = item.fEmpId,
                    fDepId = item.fDepId,                                        
                    fName = item.fName,
                    fPhone = item.fPhone,
                    fDepName = item.fDepName
                });
            }

            return employee.ToList();
        }

        // GET: api/Employee/5
        public EmployeeList Get(int fEmpId)
        {                      
            var q = from a in db.tEmployee
                    join p in db.tDepartment on a.fDepId equals p.fDepId
                    where a.fEmpId == fEmpId
                    select new
                    {
                        fEmpId = a.fEmpId,
                        fDepId = a.fDepId,
                        fName = a.fName,
                        fPhone = a.fPhone,
                        fDepName = p.fDepName
                    };

            var item = q.FirstOrDefault();
            var employee = new EmployeeList();
            employee.fEmpId = item.fEmpId;
            employee.fDepId = item.fDepId;
            employee.fName = item.fName;
            employee.fPhone = item.fPhone;
            employee.fDepName = item.fDepName;

            return employee;
        }

        // 新增 POST: api/Employee
        public int Post(string fName, string fPhone, int fDepId)
        {
            int num = 0;
            try
            {
                tEmployee employee = new tEmployee();                
                employee.fName = fName;
                employee.fPhone = fPhone;
                employee.fDepId = fDepId;                
                db.tEmployee.Add(employee);
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;
        }

        // 修改 PUT: api/Employee/5
        public int Put(int fEmpId, string fName, string fPhone, int fDepId)
        {
            int num = 0;
            try
            {
                var employee = db.tEmployee.Where(m => m.fEmpId == fEmpId).FirstOrDefault();
                employee.fEmpId = fEmpId;
                employee.fName = fName;
                employee.fPhone = fPhone;                
                employee.fDepId = fDepId;
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;
        }

        // 刪除 DELETE: api/Customer/5
        public int Delete(int fEmpId)
        {
            int num = 0;
            try
            {
                var customer = db.tEmployee.Where(m => m.fEmpId == fEmpId).FirstOrDefault();
                db.tEmployee.Remove(customer);
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}