using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{

    public class Historia
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public String diagnostico { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public String entorno { get; set; }
        [ForeignKey("sugerenciacuidado_id")]
        public SugerenciaCuidado sugerenciaCuidados_ { get; set; }
    }

}