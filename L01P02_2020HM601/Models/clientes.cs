using System.ComponentModel.DataAnnotations;

namespace L01P02_2020HM601.Models
{
    public class clientes
    {
        [Key]
        [Display(Name = "ID")]
        public int ClienteId { get; set; }
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
    }
}
