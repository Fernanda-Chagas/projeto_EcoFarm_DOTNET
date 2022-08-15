using EcoFarmAPI.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de estoque</para>
    /// <para>Criado por: Fernanda</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 10/08/2022</para>
    /// </summary>

    public interface IEstoque
    {
        Task<List<Estoque>> PegarTodosProdutosAsync();
        Task<Estoque> PegarProdutoPeloIdAsync(int id);
        Task NovoProdutoAsync(Estoque produto);
        Task AtualizarProdutoAsync (Estoque produto);
        Task DeletarProdutoAsync(int id);

    }
}
