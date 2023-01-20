using Microsoft.EntityFrameworkCore;
using ProyectoLoginMVC.Models;
using ProyectoLoginMVC.Services.Contrato;

namespace ProyectoLoginMVC.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Dbprueba2Context _context;

        public UsuarioService(Dbprueba2Context context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
            Usuario? usuario_encontrado = await _context.Usuarios.Where(u => u.Correo == correo 
                && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}
