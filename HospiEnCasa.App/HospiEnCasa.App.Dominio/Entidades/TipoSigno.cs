using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{
    public enum TipoSignoEnum
    {
        masculino,
        femenino,
    }

    public class TipoSigno
    {
        private TipoSigno(TipoSignoEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = "";
        }

        public TipoSigno() { } //For EF

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public static implicit operator TipoSigno(TipoSignoEnum @enum) => new TipoSigno(@enum);

        public static implicit operator TipoSignoEnum(TipoSigno tiposigno) => (TipoSignoEnum)tiposigno.Id;
    }

}