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
        public DateTime fechaNacimiento { get; set; }

        [ForeignKey("medico")]
        public int medico_id;
        public Medico medico { get; set; }

        [ForeignKey("enfermera")]
        public int enfermera_id { get; set; }
        public Enfermera enfermera { get; set; }
        [ForeignKey("familiarDesignado")]
        public int familiarDesignado_id { get; set; }
        public FamiliarDesignado familiarDesignado { get; set; }

        [ForeignKey("historia")]
        public int historia_id { get; set; }
        public Historia historia { get; set; }


    }
}