﻿using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> BuscarCategorias();
        IEnumerable<Categoria> BuscarCategoriasPorInfoLeilao();
        Categoria BuscarCategoriaPorId(int categoria);
    }
}
