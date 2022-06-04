using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
        ILeilaoDao _leilaoDao;
        ICategoriaDao _categoriaDao;

        public DefaultProdutoService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }

        public IEnumerable<Categoria> BuscarCategoriasComInfoLeilao()
        {
            return _categoriaDao.BuscarCategoriasComInfoLeilao();
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return _categoriaDao.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo)
        {
            return _leilaoDao.BuscarLeiloesPorTermo(termo);
        }
        
    }
}
