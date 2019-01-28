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
    public class DepartmentsController : ApiController
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: api/Customer
        public List<tDepartment> Get()
        {
            var department = db.tDepartment.OrderBy(x => x.fDepId).ToList();
            return department;
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