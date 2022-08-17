using EcoFarmAPI.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de Carrinho</para>
    /// <para>Criado por: Gustavo</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 15/08/2022</para>
    /// </summary>
    public interface ICarrinho
    {
        Task NovoCarrinhoAsync(List<Carrinho> listaProdutos);
        Task<List<Carrinho>> PegarCarrinhoPeloIdAsync(string id);
    }
}
