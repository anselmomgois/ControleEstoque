using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarCliente.Carregar
{

    public class RespostaGuardarClienteCarregar : RespostaGenerica
    {
        public List<Comum.Clases.SituacaoPessoa> SituacoesPessoa { get; set; }
        public List<Comum.Clases.Pessoa> Funcionarios { get; set; }
        public List<Comum.Clases.SegmentoComercial> SegmentosComerciais { get; set; }
        public Comum.Clases.Pessoa Cliente { get; set; }

    }
}
