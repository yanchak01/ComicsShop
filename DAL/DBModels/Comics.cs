using DAL.MainModels;
using System.Collections.Generic;

namespace DAL.DBModels
{
    public class Comics:Entity
    {
        public string Name { get; set; }
        public int NumbersOfPages { get; set; }
        public string Description { get; set; }
        public string Series { get; set; }
        public int Price { get; set; }
        public TypesComicsEnum TypesComics { get; set; }
        public ICollection<TagComics> TagComicses { get; set; }
        public ICollection<ComicsAuthorComics> EmployeeComicses { get; set; }

    }
}
