using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<Categoria> BuscarCategoriasComInfoLeilao()
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
        }
        public Categoria BuscarCategoriaPorId(int categoria)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == categoria);
        }
    }
}
