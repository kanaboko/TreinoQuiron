﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuironLojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItensTotal { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }

        public int TotalDePaginas
        {
            get{return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina);
            }
        }
    }
}