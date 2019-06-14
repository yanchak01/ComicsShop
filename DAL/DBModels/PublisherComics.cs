using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class PublisherComics
    {
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }
    }
}
