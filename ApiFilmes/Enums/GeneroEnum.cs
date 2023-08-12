using System.Text.Json.Serialization;

namespace ApiFilmes.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GeneroEnum
    {
        Acao = 0,
        Aventura = 1,
        Drama = 2,
        FiccaoCientifica = 3,
        Fantasia = 4,
        Musical = 5

    }
}
