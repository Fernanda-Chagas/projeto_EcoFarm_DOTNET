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

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> PegarTodosProdutosAsync()
        {
            var lista = await _repositorio.PegarTodosProdutosAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

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