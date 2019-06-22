using ComicsShop.DAL.DBModels;
using System.Collections.Generic;

namespace DAL.DBModels
{
    public class ComicsAuthor:Entity
    {
        public string Name { get; set; }
        public Positions Position { get; set; }
        public ICollection<ComicsAuthorComics> Authors { get; set; }

    }
}
