using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{

 //   [Table("Medicos")]
    public class Medico : Persona
    {
//        [Key]
//        private int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Especialidad { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(250)]
        public string codigo { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(500)]
        public string registro_rethus { get; set; }
/*        [ForeignKey("Personas")]
        public int Persona_id { get; set; }
        public Persona personas { get; set; }*/
    }
}