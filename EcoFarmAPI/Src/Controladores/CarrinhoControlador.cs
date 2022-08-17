using EcoFarmAPI.Src.Modelos;
using EcoFarmAPI.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Controladores
{
    [ApiController]
    [Route("api/Carrinho")]
    [Produces("application/json")]
    public class CarrinhoControlador : ControllerBase
    {

        #region Atributos

        private readonly ICarrinho _repositorio;

        #endregion

        #region Construtores

        public CarrinhoControlador(ICarrinho repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos
        [HttpPost]
        public async Task<ActionResult> NovoCarrinhoAsync([FromBody] List<Carrinho> listaProdutos)
        {
            try
            {
                await _repositorio.NovoCarrinhoAsync(listaProdutos);
                return Created($"api/Carrinho", listaProdutos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("id/{idCarrinho}")]
        public async Task<ActionResult> PegarCarrinhoPeloIdAsync([FromRoute] string id)
        {
            try
            {
                return Ok(await _repositorio.PegarCarrinhoPeloIdAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }


        #endregion
    }
}