using System;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Administradora
    {

       public string Identificador { get; set; }
       public Int32 Codigo { get; set; }
       public string Descricao { get; set; }
       public string DescricaoTela { get; set; }
       public string Observacao { get; set; }
       public Nullable<decimal> PercentualTarifa { get; set; }
       public Nullable<decimal> ValorTarifa { get; set; }
       public Nullable<decimal> PercentualTarifaAntecipada { get; set; }
       public Nullable<decimal> ValorTarifaAntecipada { get; set; }
       public Nullable<decimal> PercentualDesconto { get; set; }
       public Nullable<decimal> ValorDesconto { get; set; }
       public Byte[] ImgAdministradora { get; set; }
    }
}
