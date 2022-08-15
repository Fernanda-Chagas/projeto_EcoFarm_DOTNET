using EcoFarmAPI.Src.Modelos;
using EcoFarmAPI.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Controladores
{
    public class EstoqueControlador
    {
        [ApiController]
        [Route("api/Estoque")]
        [Produces("application/json")]
        public class PostagemControlador : ControllerBase
        {
            #region Atributos
            private readonly IEstoque _repositorio;
            #endregion

            #region Construtores
            public PostagemControlador(IEstoque repositorio)
            {
                _repositorio = repositorio;
            }
            #endregion

            #region Métodos

            [HttpGet]
            public async Task<ActionResult> PegarTodosProdutosAsync()
            {
                var lista = await _repositorio.PegarTodosProdutosAsync();
                if (lista.Count < 1) return NoContent();
                return Ok(lista);
            }

            [HttpGet("id/{idProduto}")]
            public async Task<ActionResult> PegarProdutoPeloIdAsyncc([FromRoute] int idProduto)
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

            [HttpPost]
            public async Task<ActionResult> NovaProdutoAsync([FromBody] Estoque produto)
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
            [HttpPut]
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

            [HttpDelete("deletar/{idPostagem}")]
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
}
