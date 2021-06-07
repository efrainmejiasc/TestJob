using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestJobApi.DataModels
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 2, TypeName = "VARCHAR(16)")]
        public string CveProducto { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 3, TypeName = "VARCHAR(40)")]
        public string Producto { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 4, TypeName = "VARCHAR(64)")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 5, TypeName = "DECIMAL")]
        public decimal Cantidad { get; set; }

    }
}
