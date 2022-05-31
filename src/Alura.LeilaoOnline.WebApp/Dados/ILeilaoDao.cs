using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Leilao> BuscarLeiloes();
        Leilao BuscarLeilaoPorId(int id);
        IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo);
        void AdicionarLeilao(Leilao leilao);
        void AlterarLeilao(Leilao leilao);
        void ExcluirLeilao(Leilao leilao);
    }
}
