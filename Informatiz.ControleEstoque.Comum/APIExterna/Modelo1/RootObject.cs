﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.APIExterna.Modelo1
{
    public class RootObject
    {
        public int status { get; set; }
        public int data { get; set; }
        public string msg { get; set; }
        public List<Doc> doc { get; set; }
       
    }
}
