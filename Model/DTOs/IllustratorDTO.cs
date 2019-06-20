using System.ComponentModel.DataAnnotations;
namespace Model.DTOs
{
    public class IllustratorDTO
    {
        public PositionsEnum Position = PositionsEnum.Illustrator;
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
