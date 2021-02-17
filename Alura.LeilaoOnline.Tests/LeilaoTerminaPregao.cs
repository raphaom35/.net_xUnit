using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public void RetornaMaiorValorDadoLeilaoComPeloNenosUmLance()
        {
            //Arranje - Cenário
            var leilao = new Leilao("camisa psg antiga Romario");

            //Act - metodo sobre teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;

            var valorObitito = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitito);

        }

        [Theory]
        [InlineData(1200,new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000,new double[] { 800, 900, 1000, 990 })]
        [InlineData(800,new double[] { 800 })]
        public void RetornaZeroDadoLeilaoSemLance(double valoresperado,double[] ofertas)
        {
            //Arranje - Cenário
            var leilao = new Leilao("camisa psg antiga Romario");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            
            //Act - metodo sobre teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = valoresperado;
            var valorObitito = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitito);
        }
     
       
    }
}
