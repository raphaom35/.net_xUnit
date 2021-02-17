using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProximas : IModalidadeAvaliacao
    {
        public double valordestino { get; }

        public OfertaSuperiorMaisProximas(double valordestino)
        {
            this.valordestino = valordestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                     .DefaultIfEmpty(new Lance(null, 0))
                     .Where(l => l.Valor > valordestino)
                     .OrderBy(l => l.Valor).FirstOrDefault();
        }
    }
}
