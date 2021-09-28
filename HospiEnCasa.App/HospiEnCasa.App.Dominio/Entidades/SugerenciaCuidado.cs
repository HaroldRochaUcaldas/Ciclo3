using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{

    public class SugerenciaCuidado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public DateTime fechaHora { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public String descripcion { get; set;}
    }

}