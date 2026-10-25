using Microsoft.EntityFrameworkCore;
using Proyecto.API.Models; 

namespace Proyecto.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Aquí registraráran las tablas
        public DbSet<Publicacion> Publicaciones { get; set; }

        public DbSet<Aplicacion> Aplicaciones { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<PerfilProfesional> PerfilProfesionales  { get; set; }

        public DbSet<Educacion> Educaciones { get; set; }

        public DbSet<Experiencia> Experiencias { get; set; }

        public DbSet<Certificacion> Certificaciones { get; set; }

        public DbSet<Pregunta> Preguntas { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}


