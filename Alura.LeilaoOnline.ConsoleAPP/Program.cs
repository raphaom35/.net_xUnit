using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleAPP
{
    class Program
    {
        private static void Verifica(double valorEsperado,double valorObitito)
        {
            var cor = Console.ForegroundColor;
            if (valorEsperado == valorObitito)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TEST OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TEST FALHOU ! Eperado:{valorEsperado}, Obitido:{valorObitito}");
            }
            Console.ForegroundColor = cor;
        }
        private static void LeilaoComVariosLances()
        {
            //Arranje - Cenário
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("camisa psg antiga Romario", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - metodo sobre teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObitito = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObitito);
        }
        private static void LeilaoComApenasUmLance()
        {
            //Arranje - Cenário
            IModalidadeAvaliacao modalidade = new MaiorValor();
            var leilao = new Leilao("camisa psg antiga Romario", modalidade);
            var fulano = new Interessada("Fulano", leilao);
         
            leilao.RecebeLance(fulano, 800);
            //Act - metodo sobre teste
            leilao.TerminaPregao();
            //Assert
            var valorEsperado = 800;
            var valorObitito = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObitito);
        }
            static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();


        }
    }
}
