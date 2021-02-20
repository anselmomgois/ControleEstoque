using System.Collections.Generic;


namespace Informatiz.ControleEstoque.Comum.Clases
{
  public  class Cidade
    {

      public string Identificador { get; set; }
      public int Codigo { get; set; }
      public string DDD { get; set; }
      public string Nome { get; set; }
      public string NomeCodigo { get; set; }
      public string IBGE { get; set; }
      public List<Bairro> Bairros { get; set; }

    }
}
