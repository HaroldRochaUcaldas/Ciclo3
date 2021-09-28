using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{
    public class Enfermera : Persona
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string tarjeta_profesional { get; set; }
        [Required]
        [Column(TypeName ="INTEGER")]
        public int horas_laborales { get; set; }

        [ForeignKey("paciente_id")]
        public Paciente paciente { get; set; }
    }
}