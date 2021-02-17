using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoaceitaProximoLanceMaesmolcienteRealizouOUltimoLance()
        {
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("camisa psg antiga Romario", modalidade);
            leilao.IniciaPregao();
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);
            //Act - metodo sobre teste
            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();
            //Assert
            var valorObitito = leilao.Lances.Count();
            Assert.Equal(1, valorObitito);
        } 
        [Theory]
        [InlineData(4, new double[] { 100, 1200,1400,1300 })]
        [InlineData(2,new double[] { 800,900 })]
        public void NaoPerminitirNovosLancesDAdosLeilaoFinalizado(int qtdEsperada,double[] ofertas)
        {
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("camisa psg antiga Romario", modalidade);
            leilao.IniciaPregao();
            var fulano  =new Interessada("Fulano", leilao);
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

            leilao.TerminaPregao();

            //Act - metodo sobre teste
            leilao.RecebeLance(fulano, 1000);
            //Assert
            var valorObitito = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, valorObitito);
        }
            
    }
}
