using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class TagDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
      
    }
}
