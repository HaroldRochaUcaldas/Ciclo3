using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(250)]
        public String nombres { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(250)]
        public String apellidos { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [MinLength(7)]
        [MaxLength(12)]
        [StringLength(12)]
        public String numeroTelefeno { get; set; }
        [ForeignKey("generos_id")]
        public Genero genero { get; set; }
    }
}