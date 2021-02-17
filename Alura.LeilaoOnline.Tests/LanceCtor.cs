using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaAgumentExcptionDadoValorNagativo()
        {
            var valorNagativo = -100;
            Assert.Throws<System.ArgumentException>(
                () => new Lance(null, valorNagativo)
                ); ;
        }
    }
}
