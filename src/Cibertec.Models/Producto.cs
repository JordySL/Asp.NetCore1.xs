using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cibertec.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Descripcion es Obligatorio")]
        public string Descripcion { get; set; }
        [Required]
        public int StockMinimo { get; set; }
        public DateTime  FechaRegistro { get; set; }
        [Computed]
        public int Tipo { get; set; }
    }
}
