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
        public void RetornaZeroDadoLeilaoSemLance()
        {
            //Arranje - Cenário
            var leilao = new Leilao("camisa psg antiga Romario");
            leilao.IniciaPregao();
            //Act - metodo sobre teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;

            var valorObitito = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitito);

        }
        [Fact]
        public void LancaIvalidOparationEcptionPregraoNaoIniciado()
        {
            //Arranje - Cenário
            var leilao = new Leilao("camisa psg antiga Romario");
                //Act - metodo sobre teste     
            Assert.Throws<System.InvalidOperationException>(()=> leilao.TerminaPregao());           
        }
        [Theory]
        [InlineData(1200,new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000,new double[] { 800, 900, 1000, 990 })]
        [InlineData(800,new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloNenosUmLance(double valoresperado,double[] ofertas)
        {
            //Arranje - Cenário
            var leilao = new Leilao("camisa psg antiga Romario");
            leilao.IniciaPregao();
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            for (int i = 0; i < ofertas.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(maria, ofertas[i]);
                }
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
