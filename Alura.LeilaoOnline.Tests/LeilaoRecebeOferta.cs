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
        [Theory]
        [InlineData(4, new double[] { 100, 1200,1400,1300 })]
        [InlineData(2,new double[] { 800,900 })]
        public void NaoPerminitirNovosLancesDAdosLeilaoFinalizado(int qtdEsperada,double[] ofertas)
        {
            var leilao = new Leilao("camisa psg antiga Romario");
            var fulano  =new Interessada("Fulano", leilao);
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
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
