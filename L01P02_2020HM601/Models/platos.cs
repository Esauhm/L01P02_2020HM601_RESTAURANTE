using System.ComponentModel.DataAnnotations;

namespace L01P02_2020HM601.Models
{
    public class platos
    {
        [Key]
        [Display(Name = "ID")]
        public int PlatoId { get; set; }
        [Display(Name = "Nombre del Plato")]
        public string NombrePlato { get; set; }
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}
