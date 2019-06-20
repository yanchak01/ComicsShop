using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class ComicsAuthorComics
    {
        public Guid EmployeeId { get; set; }
        public ComicsAuthor Employee { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }
    }
}
