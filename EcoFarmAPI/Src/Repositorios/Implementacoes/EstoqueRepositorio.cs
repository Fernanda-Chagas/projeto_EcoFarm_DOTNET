using EcoFarmAPI.Src.Contextos;
using EcoFarmAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IEstoque</para>
    /// <para>Criado por: Fernanda / Israel </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 11/08/2022</para>
    /// </summary>

    public class EstoqueRepositorio : IEstoque
    {
        
        #region Atributos

        private readonly EcoFarmContexto _contexto;

        #endregion Atributos 
        
        #region Construtores

        public EstoqueRepositorio(EcoFarmContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Cria novo Produto
        /// </summary>
        /// <param name="produto">Construtor para cadastrar produto</param>
        /// <returns>Ta</returns>
        public async Task NovoProdutoAsync(Estoque produto)
        {
            await _contexto.Produtos.AddAsync(
                new Estoque
                {
                    NomeProduto = produto.NomeProduto,
                    Valor = produto.Valor,
                    Quantidade = produto.Quantidade,
                    FotoProduto = produto.FotoProduto,
                    Categoria = produto.Categoria,
                    Fornecedor = await _contexto.Usuarios.FirstOrDefaultAsync(u =>u.Id == produto.Fornecedor.Id)
                });
            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos os produtos</para>
        /// </summary>
        /// <return>EstoqueModelo</return>
        public async Task<List<Estoque>> PegarTodosProdutosAsync()
        {
            return await _contexto.Produtos.ToListAsync();
        }
        public async Task<Estoque> PegarProdutoPeloIdAsync(int id)
        {

            if (!ExisteId(id)) throw new Exception("Id do produto não encontrado");

            return await _contexto.Produtos
                .Include(p=>p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
            // funções auxiliares
            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Produtos.FirstOrDefault(p => p.Id == id);
                return auxiliar != null;
            }
        }

        /// <summary>
        /// <param>Resumo: Método assíncrono para atualizar um produto</param>
        /// </summary>
        /// <param name="produto">Construtor para atualizar produto</param>
        public async Task AtualizarProdutoAsync(Estoque produto)
        {
            var produtoExistente = await PegarProdutoPeloIdAsync(produto.Id);
            produtoExistente.NomeProduto = produto.NomeProduto;
            produtoExistente.Valor = produto.Valor;
            produtoExistente.Quantidade = produto.Quantidade;
            produtoExistente.FotoProduto = produto.FotoProduto;
            produtoExistente.Categoria = produto.Categoria;
            _contexto.Produtos.Update(produtoExistente);
            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para deletar um produto</para>
        /// </summary>
        /// <param name="id">Construtor para deletear um produto pelo id</param>        
        public async Task DeletarProdutoAsync(int id)
        {
            _contexto.Produtos.Remove(await PegarProdutoPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }
       
        #endregion Métodos
    }

}