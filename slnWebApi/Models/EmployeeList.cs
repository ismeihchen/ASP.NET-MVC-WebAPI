using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace slnWebApi.Models
{
    public class EmployeeList
    {
        public int fEmpId { get; set; }
        public string fName { get; set; }
        public string fPhone { get; set; }
        public int fDepId { get; set; }

        public string fDepName { get; set; }
    }
}