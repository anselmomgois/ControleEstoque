using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Processo
    {
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }
        public Boolean PorHorario { get; set; }
        public Comum.Enumeradores.TipoProcesso Tipo { get; set; }
        public Int32 IntervaloExecucao { get; set; }
        public Int32 QuantidadeItemsExecutar
        {
            get
            {
                return Items != null && Items.Count > 0 ? Items.Count : 0;
            }
        }
        public Int32 QuantidadeTentativas { get; set; }
        public List<ItemProcesso> Items { get; set; }
        public List<ItemProcesso> ItemsExecutados { get; set; }
        public DateTime DataStatup { get; set; }
        public Nullable<DateTime> UltimaExecucao { get; set; }
        public Nullable<DateTime> InicioExecucao { get; set; }
        public Boolean EmExecucao { get; set; }
        public DateTime ProximaExecucao
        {
            get
            {
                if (InicioExecucao != null)
                {
                    return Convert.ToDateTime(InicioExecucao).AddMinutes(IntervaloExecucao);
                }
                else
                {
                    return DataStatup.AddMinutes(IntervaloExecucao);
                }

            }
        }
    }
}
