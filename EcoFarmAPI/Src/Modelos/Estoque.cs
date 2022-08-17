using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcoFarmAPI.Src.Modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_estoque no banco.</para>
    /// <para>Criado por: Samara</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 09/08/2022</para>
    /// </summary>

    [Table("tb_estoque")]
    public class Estoque
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NomeProduto { get; set; }

        public float Valor { get; set; }

        public int Quantidade { get; set; }

        public CategoriaProdutos Categoria { get; set; }

        [ForeignKey("fk_fornecedor")]
        public Usuario Fornecedor { get; set; }

        [JsonIgnore, InverseProperty("Produto")]
        public List<Carrinho> ProdutosSelecionados { get; set; }
        

        #endregion
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoriaProdutos
    {
        FRUTAS,
        LEGUMES,
        VERDURAS
    }

}
