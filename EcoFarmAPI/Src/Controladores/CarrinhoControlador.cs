using EcoFarmAPI.Src.Modelos;
using EcoFarmAPI.Src.Repositorios;
using EcoFarmAPI.Src.Servicos;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAutenticacao _servicos;

        #endregion

        #region Construtores

        public CarrinhoControlador(ICarrinho repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;
        }
        #endregion

        #region Métodos

        [HttpPost]
        [Authorize(Roles = "CLIENTE")]
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
        [Authorize(Roles = "CLIENTE")]
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