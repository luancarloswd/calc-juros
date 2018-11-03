using AutoMapper;
using CalcTest.Crosscutting.Interfaces;
using CalcTest.IoC;
using CalcTest.Service.Automapper;
using CalcTest.Service.Interfaces;
using CalcTest.Service.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CalcTest.Tests.Service
{
    public class JurosCompostosServiceTests
    {
        public class JurosCompostosControllerTests
        {
            private readonly IServiceProvider _serviceProvider;
            private readonly IJurosCompostosService _jurosCompostosService;
            private readonly IDomainNotificationManager _domainNotificationManager;

            public JurosCompostosControllerTests()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddAutoMapper(typeof(AutoMapperConfig));
                NativeInjectorBootStrapper.RegisterServices(serviceCollection);

                _serviceProvider = serviceCollection.BuildServiceProvider();
                _jurosCompostosService = _serviceProvider.GetService<IJurosCompostosService>();
                _domainNotificationManager = _serviceProvider.GetService<IDomainNotificationManager>();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Calcular_ValorInicial_Se_Tempo_Zero()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = 100,
                    Meses = 0
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Equal(resultado.ValorFinal, input.ValorInicial);
                Assert.False(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Calcular_ValorFinal_Correto()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = 100,
                    Meses = 5
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Equal(105.10M, resultado.ValorFinal);
                Assert.False(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Calcular_ValorFinal_Errado()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = 100,
                    Meses = 6
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.NotEqual(105.10M, resultado.ValorFinal);
                Assert.False(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Calcular_Com_Tempo_Negativo()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = 100,
                    Meses = -6
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Null(resultado);
                Assert.True(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Lancar_Execao_Se_ValorInicial_Negativo()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = -100,
                    Meses = 6
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Null(resultado);
                Assert.True(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Notificar_Se_Tempo_Maximo()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = 100,
                    Meses = int.MaxValue
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Null(resultado);
                Assert.True(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Deve_Notificar_Se_ValorInicial_Maximo()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = decimal.MaxValue,
                    Meses = 5
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Null(resultado);
                Assert.True(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }

            [Trait("Category", "Unit")]
            [Fact]
            public void Notificar_Se_ValorInicial_Zero()
            {
                var input = new JurosCompostosInputViewModel
                {
                    ValorInicial = 0,
                    Meses = 5
                };

                var resultado = _jurosCompostosService.Calcular(input).Result;

                Assert.Null(resultado);
                Assert.True(_domainNotificationManager.HasNotifications());

                _domainNotificationManager.Dispose();
            }
        }
    }
}
