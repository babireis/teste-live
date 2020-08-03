using FluentAssertions;
using Itau.Live.Test.Infrastructure.API.Models.CalculoImposto.Request;
using Itau.Live.Test.Infrastructure.API.Models.CalculoImposto.Response;
using Itau.Live.Test.Infrastructure.API.Repositories.CalculoImposto;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Itau.Live.Test.Run.StepDefinitions
{
    [Binding]
    public class CalculoDoImpostoDeRendaSteps
    {
        private CalculoImpostoRequest request;
        private CalculoImpostoResponse calculoImpostoResponse;

        private class DadosDeclarante
        {
            public double TabelaFipe { get; set; }
            public string TipoResidencia { get; set; }
            public double ValorResidencia { get; set; }
            public double ValorInvestimento { get; set; }
            public double ValorPoupanca { get; set; }

            public DadosDeclarante(double tabelaFipe, string tipoResidencia, double valorResidencia, double valorInvestimento, double valorPoupanca)
            {
                TabelaFipe = tabelaFipe;
                TipoResidencia = tipoResidencia;
                ValorResidencia = valorResidencia;
                ValorInvestimento = valorInvestimento;
                ValorPoupanca = valorPoupanca;
            }
        }

        [Given(@"que tenho os seguintes bens (.*) , (.*) , (.*), (.*), (.*)")]
        public void DadoQueTenhoOsSeguintesBens(double tabelaFipe, string tipoResidencia, double valorResidencia, double investimento, double poupanca)
        {
            DadosDeclarante dadosDeclarante = new DadosDeclarante(tabelaFipe, tipoResidencia, valorResidencia, investimento, poupanca);
            request = montarRequisicao(dadosDeclarante);
        }

        [Given(@"que tenho os seguintes bens")]
        public void DadoQueTenhoOsSeguintesBens(Table table)
        {
            var dados = table.CreateSet<DadosDeclarante>();
            request = montarRequisicao(dados.First());
        }

        [When(@"submeto os meus bens para cálculo do imposto")]
        public void QuandoSubmetoOsMeusBensParaCalculoDoImposto()
        {
            var repository = new CalculoImpostoRepository();
            var response = repository.PostCalculoImposto(request);
            response.StatusCode.Should().Be(200);
            calculoImpostoResponse = JsonConvert.DeserializeObject<CalculoImpostoResponse>(response.Content);

        }

        [Then(@"devo obter o valor de imposto equivalente a R\$ (.*)")]
        public void EntaoDevoObterOValorDeImpostoEquivalenteA(double ResultadoEsperado)
        {
            calculoImpostoResponse.ValorRestituido.Should().Be(ResultadoEsperado);
        }

        private CalculoImpostoRequest montarRequisicao(DadosDeclarante dados)
        {
           return new CalculoImpostoRequest()
            {
                Carros = new Carro[1] { new Carro()
                {
                    AnoModelo = "2014",
                    Marca = "Renault",
                    Modelo = "Sandero",
                    Quilometragem = 120000,
                    TabelaFipe = dados.TabelaFipe
                } },
                DinheiroInvestido = dados.ValorInvestimento,
                DinheiroPoupanca = dados.ValorPoupanca,
                Imoveis = new Imovel[1] { new Imovel()
                {
                    MetrosQuadrados = 1000,
                    TipoResidencia = dados.TipoResidencia,
                    Valor = dados.ValorResidencia
                } }
            };
        }

    }
}
