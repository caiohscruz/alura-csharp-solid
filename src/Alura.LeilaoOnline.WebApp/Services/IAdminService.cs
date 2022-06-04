using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IAdminService
    {
        IEnumerable<Leilao> BuscarLeiloesComCategoria();
        Leilao BuscarLeilaoPorId(int id);
        IEnumerable<Categoria> BuscarCategorias();
        void AdicionarLeilao(Leilao leilao);
        void AlterarLeilao(Leilao leilao);
        void IniciaPregaoLeilaoComId(int id);
        void FinalizaPregaoLeilaoComId(int id);
        void ExcluiLeilaoComId(int id);


    }
}
