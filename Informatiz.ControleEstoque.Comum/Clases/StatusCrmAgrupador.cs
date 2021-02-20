using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class StatusCrmAgrupador
    {
        public string Identificador { get; set; }
        [Required(ErrorMessage = "A descrição do status é obrigatória.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "É obrigatório informar al menos um status.")]
        public List<StatusCrm> StatusCrms { get; set; }
    }
}
