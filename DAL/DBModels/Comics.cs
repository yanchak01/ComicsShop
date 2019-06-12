using Model.MainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModels
{
   public class Comics:IModelShop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set ; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int NumbersOfPages { get; set; }

        public string Description { get; set; }

        public string Seria { get; set; }

        public int Price { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Illustrator> Illustrators { get; set; }

        public ICollection<Corrector> Correctors { get; set; }

        public ICollection<Tag> Tags { get; set; }
        
    }
}
