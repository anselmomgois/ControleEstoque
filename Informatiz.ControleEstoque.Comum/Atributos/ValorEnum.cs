using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Informatiz.ControleEstoque.Comum.Atributos
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ValorEnum : Attribute
    {

        public string Valor { get; set; }

        public ValorEnum(string valor)
        {
            this.Valor = valor;
        }

    }
}

