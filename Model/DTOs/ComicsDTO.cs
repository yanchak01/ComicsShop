using Model.MainModelsDTO;
using System;

namespace Model.DTOs
{
    public class ComicsDTO : EntityDTO
    {
        public string Name { get; set; }
        public int NumbersOfPages { get; set; }
        public string Description { get; set; }
        public string Seria { get; set; }
        public int Price { get; set; }
    }
}
