using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class EmployeeComics
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }
    }
}
