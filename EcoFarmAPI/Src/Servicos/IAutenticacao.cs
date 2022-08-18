using EcoFarmAPI.Src.Modelos;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Servicos
{   /// <summary>
    /// <para>Resumo: Interface Responsavel por representar ações de autenticação</para>
    /// <para>Criado por: Jonathan </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/08/2022</para>
    /// </summary>

    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(Usuario usuario);
        string GerarToken(Usuario usuario);
    }
}
