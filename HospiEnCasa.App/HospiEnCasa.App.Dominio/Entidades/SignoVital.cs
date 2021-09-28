using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{

    public class SignoVital
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public DateTime fecha { get; set; }
        public TipoSigno signo { get; set; }

        [MaxLength(100)]
        public float valor { get; set; }
    }

}