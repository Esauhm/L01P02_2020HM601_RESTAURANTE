using System.ComponentModel.DataAnnotations;

namespace L01P02_2020HM601.Models
{
    public class motoristas
    {
        [Key]
        [Display(Name = "ID")]
        public int MotoristaId { get; set; }
        [Display(Name = "Nombre del Motorista")]
        public string NombreMotorista { get; set; }
    }
}
