using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes.Servico
{
    public class Imagem
    {

        public static void InserirImagemCentral(Comum.Clases.Imagem objImagem, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDIMAGEM", Guid.NewGuid());
            objSql.AdicionarParametro("BITIMAGEMCENTRAL", objImagem.ImgImagemCentral);


            objSql.AdicionarTransacao(Properties.Resources.ImagemInserir);
        }

        public static void DeletarImagemCentral(ref Sql objSql)
        {

            objSql.AdicionarTransacao(Properties.Resources.ImagemDeletar);
        }

        public static Comum.Clases.Imagem RecuperarImagem()
        {

            Comum.Clases.Imagem objImagem = null;

            Sql objSql = new Sql();

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ImagemRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objImagem = new Comum.Clases.Imagem()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDIMAGEM"], typeof(string)) as string,
                    ImgImagemCentral = (byte[])frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BITIMAGEMCENTRAL"], typeof(byte[]))
                };

            }
            
            return objImagem;
        }

    }
}
