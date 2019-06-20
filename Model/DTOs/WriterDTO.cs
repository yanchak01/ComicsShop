using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class WriterDTO
    {
        public PositionsEnum Position = PositionsEnum.Writer;
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
