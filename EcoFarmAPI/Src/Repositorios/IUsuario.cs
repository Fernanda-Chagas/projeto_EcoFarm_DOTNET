using EcoFarmAPI.Src.Modelos;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Samara</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    
    public interface IUsuario
    {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);
    }

}
