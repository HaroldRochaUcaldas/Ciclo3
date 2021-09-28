using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string direccion { get; set; }
        [Required]
        [Column(TypeName = "FLOAT")]
        public float latitud { get; set; }
        [Required]
        [Column(TypeName = "FLOAT")]
        public float longitud { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ciudad { get; set; }
        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime fecha { get; set; }
        
        [ForeignKey("SignoVitales")]
        public int signovital_id { get; set; }
        public SignoVital SignoVital { get; set; }
       
        [ForeignKey("Historias")]
        public int historias_id { get; set; }
        public Historia Historia { get; set; }
    }
}