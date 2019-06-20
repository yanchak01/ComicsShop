using DAL.MainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class Employee:Entity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public ICollection<EmployeeComics> EmployeeComics { get; set; }

    }
}
