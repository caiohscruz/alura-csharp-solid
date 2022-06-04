using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<Categoria> BuscarCategoriasComInfoLeilao();
        Categoria BuscarCategoriaPorId(int id);
        IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo);
    }
}
