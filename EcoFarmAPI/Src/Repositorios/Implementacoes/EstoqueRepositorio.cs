using EcoFarmAPI.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IEstoque</para>
    /// <para>Criado por: Fernanda</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 10/08/2022</para>
    /// </summary>

    public class EstoqueRepositorio : IEstoque
    {
        public Task AtualizarPrudutoAsync(Estoque produto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletarProdutoAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task NovoProdutoAsync(Estoque produto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Estoque> PegarProdutoPeloIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Estoque>> PegarTodosProdutosAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
