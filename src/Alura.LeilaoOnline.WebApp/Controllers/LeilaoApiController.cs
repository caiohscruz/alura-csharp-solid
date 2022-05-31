﻿using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        ILeilaoDao _leilaoDao;

        public LeilaoApiController()
        {
            _leilaoDao = new LeilaoDaoComEFCore();
        }        

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _leilaoDao.BuscarLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _leilaoDao.BuscarLeilaoPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _leilaoDao.AdicionarLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _leilaoDao.AlterarLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _leilaoDao.BuscarLeilaoPorId(id);
            if (leilao == null)
            {
                return NotFound();
            }
            _leilaoDao.ExcluirLeilao(leilao);
            return NoContent();
        }

    }
}
