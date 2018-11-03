using CalcTest.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using Xunit;

namespace CalcTest.Tests.API
{
    public class JurosCompostosControllerTests
    {
        private const string _endpoint = "/api/v1/calculajuros";
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public JurosCompostosControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void Deve_Retornar_Status_Ok()
        {
            var valorInicial = 100;
            var meses = 5;

            var response = _client.GetAsync($"{_endpoint}?valorInicial={valorInicial.ToString()}&{meses.ToString()}").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void Deve_Retornar_Status_BadRequest_Se_ValorInicial_Negativo()
        {
            var valorInicial = -100;
            var meses = 5;

            var response = _client.GetAsync($"{_endpoint}?valorInicial={valorInicial.ToString()}&{meses.ToString()}").Result;
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void Deve_Retornar_Status_BadRequest_Se_Tempo_Maximo()
        {
            var valorInicial = -100;
            var meses = int.MaxValue;

            var response = _client.GetAsync($"{_endpoint}?valorInicial={valorInicial.ToString()}&{meses.ToString()}").Result;
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void Deve_Retornar_Status_BadRequest_Se_ValorInicial_Maximo()
        {
            var valorInicial = double.MaxValue;
            var meses = 5;

            var response = _client.GetAsync($"{_endpoint}?valorInicial={valorInicial.ToString()}&{meses.ToString()}").Result;
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void NDeve_Retornar_Status_BadRequest_Se_ValorInicial_Zero()
        {
            var valorInicial = double.MaxValue;
            var meses = 5;

            var response = _client.GetAsync($"{_endpoint}?valorInicial={valorInicial.ToString()}&{meses.ToString()}").Result;
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
