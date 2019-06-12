using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
   public class Comics
    {
        public Guid Id { get { return Id; } set { Id = Guid.NewGuid(); } }

        public string Name { get; set; }

        public int NumbersOfPages { get; set; }

        public string Description { get; set; }

        public string Seria { get; set; }

        public DateTime DateOfProduced { get; set; }

        public int Price { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Illustrator> Illustrators { get; set; }

        public ICollection<Corrector> Correctors { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
