using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Entities
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
    }
}
