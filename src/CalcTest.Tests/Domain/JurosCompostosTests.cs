using CalcTest.Domain.Model;
using System;
using Xunit;

namespace CalcTest.Tests.Domain
{
    public class JurosCompostosTests
    {

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Calcular_ValorInicial_Se_Tempo_Zero()
        {
            var valorInicial = 100;
            var tempo = 0;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.Equal(jurosCompostos.ValorFinal, valorInicial);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Calcular_ValorFinal_Correto()
        {
            var valorInicial = 100;
            var tempo = 5;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.Equal(105.10M, jurosCompostos.ValorFinal);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Calcular_ValorFinal_Errado()
        {
            var valorInicial = 100;
            var tempo = 6;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.NotEqual(105.10M, jurosCompostos.ValorFinal);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Calcular_Com_Tempo_Negativo()
        {
            var valorInicial = 100;
            var tempo = -6;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.Throws<InvalidOperationException>(() => new JurosCompostos(valorInicial, tempo).ValorFinal);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Lancar_Execao_Se_ValorInicial_Negativo()
        {
            var valorInicial = -100;
            var tempo = 6;

            Assert.Throws<InvalidOperationException>(() => new JurosCompostos(valorInicial, tempo).ValorFinal);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Lancar_Execao_Se_Tempo_Maximo()
        {
            var valorInicial = 100;
            var tempo = int.MaxValue;

            Assert.Throws<OverflowException>(() => new JurosCompostos(valorInicial, tempo).ValorFinal);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Lancar_Execao_Se_ValorInicial_Maximo()
        {
            var valorInicial = decimal.MaxValue;
            var tempo = 5;

            Assert.Throws<OverflowException>(() => new JurosCompostos(valorInicial, tempo).ValorFinal);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Nao_Deve_Validar_Se_ValorInicial_Zero()
        {
            var valorInicial = 0;
            var tempo = 5;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.False(jurosCompostos.Validar());
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Validar_Se_ValorInicial_Positivo()
        {
            var valorInicial = 100;
            var tempo = 5;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.True(jurosCompostos.Validar());
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Nao_Deve_Validar_Se_ValorInicial_Negativo()
        {
            var valorInicial = -100;
            var tempo = 5;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.False(jurosCompostos.Validar());
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Validar_Se_Tempo_Zero()
        {
            var valorInicial = 100;
            var tempo = 0;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.True(jurosCompostos.Validar());
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Deve_Validar_Se_Tempo_Positivo()
        {
            var valorInicial = 100;
            var tempo = 5;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.True(jurosCompostos.Validar());
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Nao_Deve_Validar_Se_Tempo_Negativo()
        {
            var valorInicial = 100;
            var tempo = -5;
            var jurosCompostos = new JurosCompostos(valorInicial, tempo);

            Assert.False(jurosCompostos.Validar());
        }
    }
}
