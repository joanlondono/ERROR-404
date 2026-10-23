using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.API.Data;
using Proyecto.API.Models;

namespace Proyecto.API.Controllers
{
    [ApiController]
    [Route("/api/Users")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPorId(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{userId}/profile")]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            var perfil = await _context.PerfilProfesionales.FirstOrDefaultAsync(p => p.UserId == userId);
            if (perfil == null)
            {
                return NotFound("El perfil no existe");
            }
            return Ok(perfil);
        }

        [HttpPost("{userId}/profile")]
        public async Task<IActionResult> PostProfile(int userId, PerfilProfesional perfil)
        {
            perfil.UserId = userId;
            _context.PerfilProfesionales.Add(perfil);
            await _context.SaveChangesAsync();
            return Ok(perfil);
        }

        [HttpPost]

        public async Task<IActionResult> PostUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserPorId), new { id = user.Id }, user);
        }

        [HttpPost("profile/{perfilId}/educacion")]
        public async Task<IActionResult> PostEducacion(int perfilId, Educacion educacion)
        {
            educacion.PerfilProfesionalId = perfilId;
            _context.Educaciones.Add(educacion);
            await _context.SaveChangesAsync();
            return Ok(educacion);
        }

        [HttpGet("profile/{perfilId}/educacion")]
        public async Task<IActionResult> GetEducacionPorPerfil(int perfilId)
        {
            var lista = await _context.Educaciones
                .Where(e => e.PerfilProfesionalId == perfilId)
                .ToListAsync();
            return Ok(lista);
        }

        [HttpPost("profile/{perfilId}/experiencia")]
        public async Task<IActionResult> PostExperiencia(int perfilId, Experiencia experiencia)
        {
            experiencia.PerfilProfesionalId = perfilId;
            _context.Experiencias.Add(experiencia);
            await _context.SaveChangesAsync();
            return Ok(experiencia);
        }

        [HttpGet("profile/{perfilId}/experiencia")]
        public async Task<IActionResult> GetExperienciaPorPerfil(int perfilId)
        {
            var lista = await _context.Experiencias
                .Where(e => e.PerfilProfesionalId == perfilId)
                .ToListAsync();
            return Ok(lista);
        }

        [HttpPost("profile/{perfilId}/certificaciones")]
        public async Task<IActionResult> PostCertificacion(int perfilId, Certificacion certificacion)
        {
            certificacion.PerfilProfesionalId = perfilId;
            _context.Certificaciones.Add(certificacion);
            await _context.SaveChangesAsync();
            return Ok(certificacion);
        }

        [HttpGet("profile/{perfilId}/certificaciones")]
        public async Task<IActionResult> GetCertificacionesPorPerfil(int perfilId)
        {
            var lista = await _context.Certificaciones
                .Where(c => c.PerfilProfesionalId == perfilId)
                .ToListAsync();
            return Ok(lista);
        }
    }
}
