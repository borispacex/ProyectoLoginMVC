using ProyectoLoginMVC.Models;

namespace ProyectoLoginMVC.Services.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
