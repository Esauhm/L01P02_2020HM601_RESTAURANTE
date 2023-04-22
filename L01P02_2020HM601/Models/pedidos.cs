using System.ComponentModel.DataAnnotations;

namespace L01P02_2020HM601.Models
{
    public class pedidos
    {
        [Key]
        [Display(Name = "ID del pedido")]
        public int PedidoId { get; set; }
        [Display(Name = "ID del motorista")]
        public int MotoristaId { get; set; }
        [Display(Name = "ID del Clientes")]
        public int ClienteId { get; set; }
        [Display(Name = "ID del plato")]
        public int PlatoId { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}
