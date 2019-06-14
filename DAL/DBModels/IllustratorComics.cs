using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class IllustratorComics
    {
        public Guid IllustratorId { get; set; }
        public Illustrator Illustrator { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }
    }
}
