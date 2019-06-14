using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModels
{
    public class AuthorComics
    {
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public Comics Comics { get; set; }
        public Guid ComicsId { get; set; }
    }
}
