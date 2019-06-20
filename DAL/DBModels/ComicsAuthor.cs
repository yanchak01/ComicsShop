using DAL.MainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class ComicsAuthor:Entity
    {
        public string Name { get; set; }
        public PositionsEnum Position { get; set; }
        public ICollection<ComicsAuthorComics> EmployeeComics { get; set; }

    }
}
