using Itau.Live.Test.Infrastructure.API.Models.CalculoImposto.Request;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itau.Live.Test.Infrastructure.API.Repositories.CalculoImposto
{
    public class CalculoImpostoRepository
    {
        private string baseUrl = "http://localhost:8080";
        private RestClient client;

        public IRestResponse PostCalculoImposto(CalculoImpostoRequest calculoImpostoRequest)
        {
            client = new RestClient(baseUrl);
            var requestBody = JsonConvert.SerializeObject(calculoImpostoRequest, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var request = new RestRequest("/calcula_imposto_renda", Method.POST);
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
    }
}
