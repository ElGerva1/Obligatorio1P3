using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiteAccesoADatos.EF
{
    public class RepositorioAtleta : IRepositorioAtleta
    {
        private ComiteContext _context;
        public RepositorioAtleta(ComiteContext context)
        {
            _context = context;
        }

        public void Add(Atleta obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("No se recibio el atleta vàlido");
            }
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Atleta> GetAll()
        {
            return _context.atletas
               .Include(a => a.Pais)
               .Include(a => a.Disciplinas)
               .OrderBy(a => a.Pais.NombrePais)  // Asegúrate de que 'Nombre' es la propiedad correcta en 'Pais'
               .ThenBy(a => a.Nombre)       // Suponiendo que 'Apellido' es la propiedad que contiene el apellido del atleta
               .ToList();
        }

        public Atleta GetById(int id)
        {
            Atleta? a = null;
            a =
                _context.atletas.Include(a=> a.Pais).Include(a => a.Disciplinas)
                .FirstOrDefault(atleta => atleta.ID == id);
            if (a == null)
            {
                throw new Exception($"No se encontro la el atleta con id {id}");
            }
            return a;
        }
        public void Edit(Atleta obj)
        {
            Atleta a = GetById(obj.ID);
            a.Nombre = obj.Nombre;
            a.Sexo = obj.Sexo;
            foreach(int i in obj.DisciplinasIds){
                Disciplina? d = null;
                d =
                    _context.disciplinas
                    .FirstOrDefault(disciplina => disciplina.ID == i);
                a.Disciplinas.Add(d);
                a.DisciplinasIds.Add(i);
            }
            _context.atletas.Update(a);
            _context.SaveChanges();
        }
    }
}
