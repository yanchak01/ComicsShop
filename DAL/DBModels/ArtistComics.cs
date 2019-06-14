using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModels
{
    public class ArtistComics
    {
        public Artist Artist { get; set; }
        public Guid ArtistId { get; set; }
        public Comics Comics { get; set; }
        public Guid ComicsId { get; set; }

    }
}
