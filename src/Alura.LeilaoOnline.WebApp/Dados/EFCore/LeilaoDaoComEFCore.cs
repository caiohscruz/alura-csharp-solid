using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoComEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes
                .Include(l => l.Categoria);
        }

        public Leilao BuscarLeilaoPorId(int id)
        {
            return _context.Leiloes.Find(id);
        }
        
        public IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo)
        {
            return _context.Leiloes
                .Include(l => l.Categoria)
                .Where(l => string.IsNullOrWhiteSpace(termo) ||
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
        }

        public void AdicionarLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }
        
        public void AlterarLeilao(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void ExcluirLeilao(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
