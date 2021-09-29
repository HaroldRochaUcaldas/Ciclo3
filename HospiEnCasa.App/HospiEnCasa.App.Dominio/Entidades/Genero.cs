using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HospiEnCasa.App.Dominio
{

    public static class EnumExtensionMethods  
    {  
        public static string GetEnumDescription(this Enum enumValue)  
        {  
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());  
  
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);  
  
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();  
        }  
    } 
    public enum GeneroEnum
    {
        [Description("Genero con el cual se registro el paciente el cual es masculino")]
        masculino,
        [Description("Genero con el cual se registro el paciente el cual es masculino")]
        femenino,
    }
    public class Genero
    {
        public Genero(GeneroEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription(); 
        }

        public Genero() { } //For EF

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