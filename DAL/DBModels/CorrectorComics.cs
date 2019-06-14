using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.DBModels
{
   public class CorrectorComics
    {
        public Guid CorrectorId { get; set; }
        public Corrector Corrector { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }

    }
}
