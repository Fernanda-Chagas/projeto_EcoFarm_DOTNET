using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoFarmAPI.Src.Modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_carrinho no banco.</para>
    /// <para>Criado por: Samara</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 09/08/2022</para>
    /// </summary>

    [Table("tb_carrinho")]
    public class Carrinho
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Quantidade { get; set; }  

        [ForeignKey("fk_cliente")]
        public Usuario Cliente { get; set; }

        [ForeignKey("fk_estoque")]
        public Estoque Estoque { get; set; }

        #endregion

    }
}

