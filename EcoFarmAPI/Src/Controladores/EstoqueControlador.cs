using EcoFarmAPI.Src.Modelos;
using EcoFarmAPI.Src.Repositorios;
using EcoFarmAPI.Src.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Controladores
{

    [ApiController]
    [Route("api/Estoque")]
    [Produces("application/json")]
    public class EstoqueControlador : ControllerBase
    {
        #region Atributos

        private readonly IEstoque _repositorio;
        private readonly IAutenticacao _servicos;

        #endregion

        #region Construtores

        public EstoqueControlador(IEstoque repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;

        }

        #endregion

        #region Métodos
        /// <summary>
        /// Novo Produto
        /// </summary>
        /// <param name="produto">Novo Produto</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// <para>POST /api/Estoque</para>
        /// <para>{</para>
        /// <para>"nomeProduto": "Laranja",</para>
        /// <para>"valor": 0,</para>
        /// <para>"quantidade": 0,</para>
        /// <para>"fotoProduto": "string",</para>
        /// <para>"categoria": "FRUTAS",</para>
        /// <para>}</para>
        ///
        /// </remarks>
        /// <response code="201">Retorna produto criado</response>
        /// <response code="401">Produto já cadastrado</response>

        [HttpPost]
        [Authorize(Roles = "FORNECEDOR")]
        public async Task<ActionResult> NovoProdutoAsync([FromBody] Estoque produto)
        {
            try
            {
                await _repositorio.NovoProdutoAsync(produto);
                return Created($"api/Produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Lista todos os Produtos
        /// </summary>
        /// <param>Lista todos os Produtos</param>
        /// <returns>ActionResult</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> PegarTodosProdutosAsync()
        {
            var lista = await _repositorio.PegarTodosProdutosAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        /// <summary>
        /// Busca produto pelo ID
        /// </summary>
        /// <param>Busca produto pelo ID</param>
        /// <returns>ActionResult</returns>
        [HttpGet("id/{idProduto}")]
        [Authorize(Roles = "FORNECEDOR")]
        public async Task<ActionResult> PegarProdutoPeloIdAsync([FromRoute] int idProduto)
        {
            try
            {
                return Ok(await _repositorio.PegarProdutoPeloIdAsync(idProduto));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        /// <summary>
        /// Atualiza o produto existente
        /// </summary>
        /// <param name="produto">Atualiza o produto existente</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// <para>PUT /api/Estoque</para>
        /// <para>{</para>
        /// <para>"nomeProduto": "Laranja",</para>
        /// <para>"valor": 0,</para>
        /// <para>"quantidade": 0,</para>
        /// <para>"fotoProduto": "string",</para>
        /// <para>"categoria": "FRUTAS",</para>
        /// <para>}</para>
        ///
        /// </remarks>
        [HttpPut]
        [Authorize(Roles = "FORNECEDOR")]
        public async Task<ActionResult> AtualizarProdutoAsync([FromBody] Estoque produto)
        {
            try
            {
                await _repositorio.AtualizarProdutoAsync(produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
        /// <summary>
        /// Deleta um produto pelo ID
        /// </summary>
        /// <param>Deleta um produto pelo ID</param>
        /// <returns>ActionResult</returns>
        [HttpDelete("deletar/{idProduto}")]
        [Authorize(Roles = "FORNECEDOR")]
        public async Task<ActionResult> DeletarProdutoAsync([FromRoute] int idProduto)
        {
            try
            {
                await _repositorio.DeletarProdutoAsync(idProduto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }

        }
        #endregion
    }

}