﻿using System.Reflection.Metadata;
using System.Collections.Generic;
using System;
using HospiEnCasa.App.Persistencia;
//using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio programa!");
            AddPaciente();
            GetPaciente();
        }

        private static IRepositorioPaciente _repoPaciente=new RepositorioPaciente(new Persistencia.AppContext());
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                nombres = "Harold",
                apellidos = "Rocha",
                numeroTelefeno = "3166227466",
                genero_id=1,
                //genero = new Genero(GeneroEnum.masculino),
                direccion = "cr 51 n 134-67",
                latitud = 1.5844F,
                longitud = 1.111F,
                ciudad = "Bogotá",
                fechaNacimiento =new DateTime(1990,04,12)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void GetPaciente()
        {
           
            Paciente paciente=_repoPaciente.GetPaciente(2);
            Console.WriteLine(paciente.Id);
            Console.WriteLine(paciente.genero_id);
            Console.WriteLine(paciente.genero.Name);            
        }
    }
}
