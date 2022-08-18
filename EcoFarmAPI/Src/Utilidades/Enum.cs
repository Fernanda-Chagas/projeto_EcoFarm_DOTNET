using System.Text.Json.Serialization;

namespace EcoFarmAPI.Src.Utilidades
{
    public class Enum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TipoUsuario
        {
            CLIENTE,
            FORNECEDOR
        }
    }
}
