using EcoFarmAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EcoFarmAPI.Src.Contextos
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 17/07/2022</para>
    /// </summary>
    public class EcoFarmContexto : DbContext
    {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Estoque> Produtos { get; set; }

        public DbSet<Carrinho> Carrinhos { get; set; }

        #endregion

        #region Construtores
        public EcoFarmContexto(DbContextOptions<EcoFarmContexto> opt) :
        base(opt)
        {

        }
        #endregion
    }

}
