using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospiEnCasa.App.Dominio
{
    public enum GeneroEnum
    {
        masculino,
        femenino,
    }

    public class Genero
    {
        private Genero(GeneroEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = "";
        }

        protected Genero() { } //For EF

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public static implicit operator Genero(GeneroEnum @enum) => new Genero(@enum);

        public static implicit operator GeneroEnum(Genero genero) => (GeneroEnum)genero.Id;
    }

}