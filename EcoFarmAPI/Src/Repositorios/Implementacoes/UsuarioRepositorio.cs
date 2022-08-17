using EcoFarmAPI.Src.Modelos;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios.Implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        public Task NovoUsuarioAsync(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> PegarUsuarioPeloEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
