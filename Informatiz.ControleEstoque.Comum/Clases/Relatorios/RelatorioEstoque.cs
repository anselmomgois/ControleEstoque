using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios
{
   [Serializable]
   public class RelatorioEstoque
    {

       public string Descricao;
       public string CodigoBarras;
       public Int32 Codigo;
       public decimal Estoque;
       public Int32 CodigoFilial;
       public string DescricaoFilial;
       public string TelefoneFixo;
       public string TelefoneFax;
       public string TelefoneCelular;
       public string Email;

    }
}
