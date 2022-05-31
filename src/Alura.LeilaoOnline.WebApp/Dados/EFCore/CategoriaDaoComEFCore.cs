using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoComEFCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoComEFCore()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }
    }
}
