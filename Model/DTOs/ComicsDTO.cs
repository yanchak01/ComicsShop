using Model.MainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
   public class ComicsDTO:IModelShop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int NumbersOfPages { get; set; }

        public string Description { get; set; }

        public string Seria { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int Price { get; set; }
       
    }
}
