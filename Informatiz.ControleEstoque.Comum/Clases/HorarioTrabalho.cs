using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class HorarioTrabalho
    {

       public string Identificador { get; set; }
       public Enumeradores.Enumeradores.CodigoDiaSemana CodDiaSemana { get; set; }
       public string NomeDiaSemana { get; set; }
       public string DesHoraInicio { get; set; }
       public string DesHoraFim { get; set; }
    }
}
