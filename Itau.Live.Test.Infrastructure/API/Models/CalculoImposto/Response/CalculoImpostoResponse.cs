using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Live.Test.Infrastructure.API.Models.CalculoImposto.Response
{
    public class CalculoImpostoResponse
    {
        [JsonProperty("valor_restituido")]
        public double ValorRestituido { get; set; }
    }
}
