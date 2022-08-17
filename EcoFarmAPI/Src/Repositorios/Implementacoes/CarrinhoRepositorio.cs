using EcoFarmAPI.Src.Contextos;
using EcoFarmAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoFarmAPI.Src.Repositorios.Implementacoes
{
    public class CarrinhoRepositorio : ICarrinho
    {
        #region Atributos

        private readonly EcoFarmContexto _contexto;
        
        #endregion


        #region Construtores

        public CarrinhoRepositorio(EcoFarmContexto contexto)
        {
            _contexto = contexto;
        }
        
        #endregion


        #region Métodos

        public async Task NovoCarrinhoAsync(List<Carrinho> listaProdutos)
        {
            var id = Guid.NewGuid().ToString();
            foreach (Carrinho item in listaProdutos)
            {
                await _contexto.Carrinhos.AddAsync(
                    new Carrinho { 
                        IdCompra = id,
                        Cliente = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == item.Cliente.Id),
                        Produto = await _contexto.Produtos.FirstOrDefaultAsync(p => p.Id == item.Produto.Id),
                        Quantidade = item.Quantidade,
                        Data = DateTime.Now
                    });
                await _contexto.SaveChangesAsync();

            }
        }
        public async Task<List<Carrinho>> PegarCarrinhoPeloIdAsync(string id)
        {
            return await _contexto.Carrinhos
                .Where(c => c.IdCompra == id)
                .ToListAsync();
        }

        #endregion
    }
}
