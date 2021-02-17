using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{

    public enum EstadoLeilao
    {
        LeilaAntesDoPregao,
        LeilaoEmAdameto,
        LeilaoFinalizado
    }

    public class Leilao
    {
        private Interessada _ultimoCliente;
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }

        public Lance Ganhador { get; private set; }

        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaAntesDoPregao;
        }
        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilao.LeilaoEmAdameto) && (cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceAceito(cliente,valor))
            {         
                    _lances.Add(new Lance(cliente, valor));
                    _ultimoCliente = cliente;
  
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAdameto;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAdameto)
            {
                throw new System.InvalidOperationException();
            }
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null,0))
                .OrderBy(l => l.Valor).LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
