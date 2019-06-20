using DAL.MainModels;
using System.Collections.Generic;

namespace DAL.DBModels
{
    public class Comics:Entity
    {
        public string Name { get; set; }
        public int NumbersOfPages { get; set; }
        public string Description { get; set; }
        public string Seria { get; set; }
        public int Price { get; set; }
        public ICollection<TagComics> TagComicses { get; set; }
        public ICollection<EmployeeComics> EmployeeComicses { get; set; }
    }
}
