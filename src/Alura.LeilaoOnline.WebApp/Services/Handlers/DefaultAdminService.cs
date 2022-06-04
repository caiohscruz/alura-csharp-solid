using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDao _leilaoDao;
        ICategoriaDao _categoriaDao;

        public DefaultAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }
        public IEnumerable<Leilao> BuscarLeiloesComCategoria()
        {
            return _leilaoDao.BuscarLeiloes();
        }
        public Leilao BuscarLeilaoPorId(int id)
        {
            return _leilaoDao.BuscarLeilaoPorId(id);
        }
        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _categoriaDao.BuscarCategorias();
        }

        public void AdicionarLeilao(Leilao leilao)
        {
            _leilaoDao.AdicionarLeilao(leilao);
        }

        public void AlterarLeilao(Leilao leilao)
        {
            _leilaoDao.AlterarLeilao(leilao);
        }
        public void IniciaPregaoLeilaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarLeilaoPorId(id);
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _leilaoDao.AlterarLeilao(leilao);
            }
        }
        public void FinalizaPregaoLeilaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarLeilaoPorId(id);
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _leilaoDao.AlterarLeilao(leilao);
            }
        }
        public void ExcluiLeilaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarLeilaoPorId(id);
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _leilaoDao.ExcluirLeilao(leilao);
            }
        }

    }
}
