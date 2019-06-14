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

        public ICollection<AuthorComics> AuthorComicses { get; set; }

        public ICollection<ArtistComics> ArtistComicses { get; set; }

        public ICollection<IllustratorComics> IllustratorComicses { get; set; }

        public ICollection<CorrectorComics> CorrectorsComicses { get; set; }

        public ICollection<PublisherComics> PublisherComicses { get; set; }

        public ICollection<TagComics> TagComicses { get; set; }
        
    }
}
