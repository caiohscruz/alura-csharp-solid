using Alura.LeilaoOnline.WebApp.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
