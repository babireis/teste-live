using Newtonsoft.Json;
using System;

namespace Itau.Live.Test.Infrastructure.API.Models.CalculoImposto.Request
{
    public class CalculoImpostoRequest
    {
        [JsonProperty("carros")]
        public Carro[] Carros { get; set; }

        [JsonProperty("dinheiro_investido")]
        public double DinheiroInvestido { get; set; }

        [JsonProperty("dinheiro_poupanca")]
        public double DinheiroPoupanca { get; set; }

        [JsonProperty("imoveis")]
        public Imovel[] Imoveis { get; set; }

    }

    public class Carro
    {
        [JsonProperty("ano_modelo")]
        public string AnoModelo { get; set; }

        [JsonProperty("quilometragem")]
        public int Quilometragem { get; set; }

        [JsonProperty("marca")]
        public string Marca { get; set; }

        [JsonProperty("modelo")]
        public string Modelo { get; set; }

        [JsonProperty("tabela_fipe")]
        public double TabelaFipe { get; set; }
    }

    public class Imovel
    {
        [JsonProperty("metros_quadrados")]
        public int MetrosQuadrados { get; set; }

        [JsonProperty("tipo_residencia")]
        public string TipoResidencia { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }
    }
}
