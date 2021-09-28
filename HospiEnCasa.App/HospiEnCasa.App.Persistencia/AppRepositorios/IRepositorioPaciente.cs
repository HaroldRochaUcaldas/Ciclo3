using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        Boolean DeletePaciente(int idPaciente);
        Paciente GetPaciente(int idPaciente); 

    }

}