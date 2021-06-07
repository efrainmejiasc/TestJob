using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestJobApi.DataModels
{
    [Table("UserApp")]
    public class UserApp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string Rol { get; set; }

        [Column(Order = 5, TypeName = "DATETIME")]
        public DateTime CreatedDate { get; set; }
    }
}
