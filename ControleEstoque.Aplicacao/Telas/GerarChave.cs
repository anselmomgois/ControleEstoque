using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GerarChave : TelaBase.BaseCE
    {
        public GerarChave()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {

            MontarMenu(false);

            base.Inicializar();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                ContratoServico.GerarChave.Peticao objPeticao = new ContratoServico.GerarChave.Peticao();

                objPeticao.SessoesInfinita = chkSessoesInfinitas.Checked;

                if (!string.IsNullOrEmpty(txtQuantidadeSessoes.Text))
                {
                    objPeticao.QuantidadeSessoes = Convert.ToInt32(txtQuantidadeSessoes.Text);
                }

                if (!string.IsNullOrEmpty(txtValidadeDias.Text))
                {
                    objPeticao.NumValidade = Convert.ToInt32(txtValidadeDias.Text);
                }

                objPeticao.ValidadeInfinita = chkValidadeInfinita.Checked;

                ContratoServico.GerarChave.Respuesta objRespuesta = LogicaNegocio.Servico.Chave.GerarChave(objPeticao);

                if (objRespuesta.CodigoErro != 0)
                {
                    if (objRespuesta.CodigoErro == Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO))
                    {
                        throw new Exception(objRespuesta.DescricaoErro);
                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio((Execao.Constantes.CodigoErro)(objRespuesta.CodigoErro), objRespuesta.DescricaoErro);
                    }


                }

                lblChaveGerada.Text = objRespuesta.ChaveGerada;
                
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtQuantidadeSessoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValidadeDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
