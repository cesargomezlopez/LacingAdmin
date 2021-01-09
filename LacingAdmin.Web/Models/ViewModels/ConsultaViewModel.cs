using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class ConsultaViewModel
    {
        public List<Docente> ListaDocentes { get; set; }
        public List<Facultad> ListaFacultades { get; set; }
        public List<Carrera> ListaCarreras { get; set; }
        public List<Curso> ListaCursos { get; set; }
        public List<Laboratorio> ListaLaboratorios { get; set; }
        public List<Horario> ListaHorariosConsulta { get; set; }
    }
}