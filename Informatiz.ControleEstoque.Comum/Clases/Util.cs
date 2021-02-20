using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Util
    {

        public static void FiltrarUnidadesMedidas(List<Comum.Clases.UnidadeMedida> objUnidadesMedidaGeral,
                                                  ref List<Comum.Clases.UnidadeMedida> objUnidadesMedida)
        {
            if (objUnidadesMedida != null && objUnidadesMedida.Count > 0)
            {
                List<Comum.Clases.UnidadeMedida> objUnidadesFiltradas = null;
                List<Comum.Clases.UnidadeMedida> objUnidadesComparar = objUnidadesMedida;

                foreach (Comum.Clases.UnidadeMedida unidade in objUnidadesMedida.FindAll(ump => ump.UnidademedidaPai != null))
                {
                    if (objUnidadesMedidaGeral.Exists(um => um.UnidademedidaPai != null && um.UnidademedidaPai.Identificador == unidade.Identificador && !objUnidadesComparar.Exists(ume => ume.Identificador == um.Identificador)))
                    {
                        if (objUnidadesFiltradas == null) { objUnidadesFiltradas = new List<Comum.Clases.UnidadeMedida>(); }
                        objUnidadesFiltradas.Add(objUnidadesMedidaGeral.Find(um => um.UnidademedidaPai != null && um.UnidademedidaPai.Identificador == unidade.Identificador && !objUnidadesComparar.Exists(ume => ume.Identificador == um.Identificador)));
                    }
                }

                if (objUnidadesFiltradas != null && objUnidadesFiltradas.Count > 0)
                {
                    FiltrarUnidadesMedidas(objUnidadesMedidaGeral, ref objUnidadesFiltradas);
                    objUnidadesMedida.AddRange(objUnidadesFiltradas);
                }

            }
        }

        public static System.Drawing.Bitmap byteArrayToImage(byte[] data)
        {
            if (data != null && data.Length > 0)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                {
                    return new System.Drawing.Bitmap(ms);
                }
            }
            return null;
        }

    }
}
