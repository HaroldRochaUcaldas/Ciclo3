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
        [ForeignKey("SugerenciaCuidados")]
        public int SugerenciaCuidado_id { get; set; }
        public SugerenciaCuidado SugerenciaCuidados { get; set; }
    }

}