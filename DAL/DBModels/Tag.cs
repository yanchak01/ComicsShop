using ComicsShop.DAL.DBModels;
using System.Collections.Generic;

namespace DAL.DBModels
{
    public class Tag:Entity
    {
        public string Name { get; set; }
        public ICollection<TagComics> Tags { get; set; }
    }
}
