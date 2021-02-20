using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarPergunta : TelaBase.BaseCE
    {
        public GuardarPergunta(Comum.Clases.Pergunta objPergunta)
        {
            InitializeComponent();

           _objPergunta = objPergunta;

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private Comum.Clases.Pergunta _objPergunta;
        private List<Comum.Clases.PerguntaOpcao> _objOpcoes;
        private List<frmWindows.Item> TiposComponentes;

        #endregion

        #region"Propriedades"

        public Comum.Clases.Pergunta objPerguntaTrans
        {
            get
            {
                return _objPergunta;
            }
        }

        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(lblPergunta);
            this.pnlBase.Controls.Add(txtPergunta);
            this.pnlBase.Controls.Add(lblTipoPergunta);
            this.pnlBase.Controls.Add(ddlTipoPergunta);
            this.pnlBase.Controls.Add(lblRespostaObrigatoria);
            this.pnlBase.Controls.Add(lblSomenteNumeros);
            this.pnlBase.Controls.Add(chkObrigatorio);
            this.pnlBase.Controls.Add(chkSomenteNumeros);
            this.pnlBase.Controls.Add(gpbOpcoes);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            CarregarTiposComponente();
            CarregarGridPerguntas();

            CarregarControlesTela();


        }


        private void CarregarGridPerguntas()
        {

            dgvPerguntas.Rows.Clear();

            if (_objOpcoes != null && _objOpcoes.Count > 0)
            {

                foreach (Comum.Clases.PerguntaOpcao objOpcao in _objOpcoes)
                {

                    dgvPerguntas.Rows.Add();
                    objOpcao.IdentificadorAuxiliar = Guid.NewGuid().ToString();
                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colIdentificadorPerguntaProv.Index].Value = objOpcao.IdentificadorAuxiliar;
                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colIdentificador.Index].Value = objOpcao.Identificador;
                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colPergunta.Index].Value = objOpcao.Descricao;

                }
            }


            dgvPerguntas.Rows.Add();
            dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colEditarPergunta.Index].Value = Properties.Resources.fundo_branco;

            frmWindows.Item objItem = null;

            if (ddlTipoPergunta.SelectedItem != null)
            {
                objItem = (frmWindows.Item)(frmWindows.Util.RecuperarItemSelecionado(ddlTipoPergunta, TiposComponentes, "Identificador"));
            }


            if ((_objPergunta != null && _objPergunta.TipoComponente != Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX) ||
                 ((objItem == null) || (objItem != null && objItem.Identificador != Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX.GetHashCode().ToString())))
            {
                dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colExcluirPergunta.Index].Value = Properties.Resources.new_gray;
                dgvPerguntas.Enabled = false;
            }
            else
            {
                dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colExcluirPergunta.Index].Value = Properties.Resources._new;
            }


        }

        private void CarregarTiposComponente()
        {

            TiposComponentes = new List<frmWindows.Item>();

            TiposComponentes.Add(new frmWindows.Item
            {
                Identificador = Comum.Enumeradores.Enumeradores.TipoComponente.TEXTBOX.GetHashCode().ToString(),
                Descricao = "Resposta de texto"
            });

            TiposComponentes.Add(new frmWindows.Item
            {
                Identificador = Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX.GetHashCode().ToString(),
                Descricao = "Usuário poderá seleciona uma das possiveis respostas"
            });

            TiposComponentes.Add(new frmWindows.Item
            {
                Identificador = Comum.Enumeradores.Enumeradores.TipoComponente.SIMONAO.GetHashCode().ToString(),
                Descricao = "Sim ou Não"
            });

            TiposComponentes.Add(new frmWindows.Item
            {
                Identificador = Comum.Enumeradores.Enumeradores.TipoComponente.CHECKBOX.GetHashCode().ToString(),
                Descricao = "Verdadeiro ou Falso"
            });

            ddlTipoPergunta = frmWindows.Util.PreencherCombobox(ddlTipoPergunta, TiposComponentes);

        }

        private void CarregarControlesTela()
        {

            if (_objPergunta != null)
            {

                txtPergunta.Text = _objPergunta.DesPergunta;
                chkObrigatorio.Checked = _objPergunta.Obrigatoria;
                chkSomenteNumeros.Checked = _objPergunta.Numerico;
                _objOpcoes = _objPergunta.Opcoes;

                CarregarGridPerguntas();

                if (_objOpcoes == null) { _objOpcoes = new List<Comum.Clases.PerguntaOpcao>(); }

                ddlTipoPergunta = (ComboBox)(frmWindows.Util.SelecionarItemControle(ddlTipoPergunta,
                                  _objPergunta.TipoComponente.GetHashCode().ToString(), "Identificador"));


            }
            else
            {
                _objOpcoes = new List<Comum.Clases.PerguntaOpcao>();
            }
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {


            if (dgvPerguntas.Rows.Count - 1 != RowIndex)
            {
                Comum.Clases.PerguntaOpcao objPergAux = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                         where objP.IdentificadorAuxiliar == Identificador.Value
                                                         select objP).FirstOrDefault();

                GuardarPerguntaOpcao frmPergunta = new GuardarPerguntaOpcao(objPergAux);

                if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmPergunta.objOpcaoTrans != null)
                    {
                        if (_objOpcoes == null) _objOpcoes = new List<Comum.Clases.PerguntaOpcao>();

                        Comum.Clases.PerguntaOpcao objPerg = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                              where objP.IdentificadorAuxiliar == frmPergunta.objOpcaoTrans.IdentificadorAuxiliar
                                                              select objP).FirstOrDefault();

                        if (objPerg != null)
                        {
                            objPerg.Descricao = frmPergunta.objOpcaoTrans.Descricao;

                        }
                        else
                        {
                            _objOpcoes.Add(frmPergunta.objOpcaoTrans);
                        }

                        CarregarGridPerguntas();
                    }
                }
            }
            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        


        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            if (dgvPerguntas.Rows.Count - 1 != RowIndex)
            {
                if (_objOpcoes.Count > 0)
                {
                    if (MessageBox.Show("Deseja excluir o Registro?", "I - GERENCE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Comum.Clases.PerguntaOpcao objPerg = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                              where objP.IdentificadorAuxiliar == Identificador.Value
                                                              select objP).FirstOrDefault();

                        if (objPerg != null)
                        {
                            _objOpcoes.RemoveAll(o => o.IdentificadorAuxiliar == objPerg.IdentificadorAuxiliar);
                            CarregarGridPerguntas();
                        }
                    }
                }
            }

                base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        private void dgvPerguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPerguntas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditarPergunta.Index || e.ColumnIndex == colExcluirPergunta.Index)
                        {

                            if (e.ColumnIndex == colExcluirPergunta.Index)
                            {

                                if (dgvPerguntas.Rows.Count - 1 == e.RowIndex)
                                {

                                    GuardarPerguntaOpcao frmPergunta = new GuardarPerguntaOpcao(null);

                                    if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (frmPergunta.objOpcaoTrans != null)
                                        {
                                            if (_objOpcoes == null) _objOpcoes = new List<Comum.Clases.PerguntaOpcao>();

                                            Comum.Clases.PerguntaOpcao objPerg = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                                                  where objP.IdentificadorAuxiliar == frmPergunta.objOpcaoTrans.IdentificadorAuxiliar
                                                                                  select objP).FirstOrDefault();

                                            if (objPerg != null)
                                            {
                                                objPerg.Descricao = frmPergunta.objOpcaoTrans.Descricao;
                                            }
                                            else
                                            {
                                                _objOpcoes.Add(frmPergunta.objOpcaoTrans);
                                            }

                                            CarregarGridPerguntas();
                                        }
                                    }
                                }
                                else
                                {
                                    if (_objOpcoes.Count > 0)
                                    {
                                        if (MessageBox.Show("Deseja excluir o Registro?", "I - GERENCE", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {
                                            Comum.Clases.PerguntaOpcao objPerg = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                                                  where objP.IdentificadorAuxiliar == dgvPerguntas.Rows[e.RowIndex].Cells[colIdentificadorPerguntaProv.Index].Value
                                                                                  select objP).FirstOrDefault();

                                            if (objPerg != null)
                                            {
                                                _objOpcoes.RemoveAll(o => o.IdentificadorAuxiliar == objPerg.IdentificadorAuxiliar);
                                                CarregarGridPerguntas();
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {

                                Comum.Clases.PerguntaOpcao objPergAux = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                                    where objP.IdentificadorAuxiliar == dgvPerguntas.Rows[e.RowIndex].Cells[colIdentificadorPerguntaProv.Index].Value
                                                                    select objP).FirstOrDefault();

                                GuardarPerguntaOpcao frmPergunta = new GuardarPerguntaOpcao(objPergAux);

                                if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frmPergunta.objOpcaoTrans != null)
                                    {
                                        if (_objOpcoes == null) _objOpcoes = new List<Comum.Clases.PerguntaOpcao>();

                                        Comum.Clases.PerguntaOpcao objPerg = (from Comum.Clases.PerguntaOpcao objP in _objOpcoes
                                                                              where objP.IdentificadorAuxiliar == frmPergunta.objOpcaoTrans.IdentificadorAuxiliar
                                                                         select objP).FirstOrDefault();

                                        if (objPerg != null)
                                        {
                                            objPerg.Descricao = frmPergunta.objOpcaoTrans.Descricao;
                                         
                                        }
                                        else
                                        {
                                            _objOpcoes.Add(frmPergunta.objOpcaoTrans);
                                        }

                                        CarregarGridPerguntas();
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlTipoPergunta.SelectedItem == null)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório Selecionar o tipo de pergunta");
                }

                if (string.IsNullOrEmpty(txtPergunta.Text))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório informar a pergunta");
                }

                if (_objPergunta == null) _objPergunta = new Comum.Clases.Pergunta();


                _objPergunta.DesPergunta = txtPergunta.Text;
                _objPergunta.Opcoes = _objOpcoes;
                _objPergunta.Numerico = chkSomenteNumeros.Checked;
                _objPergunta.Obrigatoria = chkObrigatorio.Checked;

                frmWindows.Item objItem = null;

                if (ddlTipoPergunta.SelectedItem != null)
                {
                    objItem = (frmWindows.Item)(frmWindows.Util.RecuperarItemSelecionado(ddlTipoPergunta, TiposComponentes, "Identificador"));

                    if (objItem != null)
                    {
                        _objPergunta.TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(Convert.ToInt32(objItem.Identificador));
                    }
                }


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Execao.ExecaoNegocio ex)
            {

                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void ddlTipoPergunta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlTipoPergunta.SelectedItem != null)
                {
                    frmWindows.Item objItem = (frmWindows.Item)(frmWindows.Util.RecuperarItemSelecionado(ddlTipoPergunta, TiposComponentes, "Identificador"));

                    if (objItem != null &&
                        (Comum.Enumeradores.Enumeradores.TipoComponente)(Convert.ToInt32(objItem.Identificador)) == Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX)
                    {
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colExcluirPergunta.Index].Value = Properties.Resources._new;
                        dgvPerguntas.Enabled = true;
                    }
                    else
                    {
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colExcluirPergunta.Index].Value = Properties.Resources.new_gray;
                        dgvPerguntas.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvPerguntas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvPerguntas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditarPergunta.Index || e.ColumnIndex == colExcluirPergunta.Index)
                        {

                            if (e.ColumnIndex == colEditarPergunta.Index && e.RowIndex == dgvPerguntas.Rows.Count - 1)
                            {
                                //Define o cursor para default
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                //Define o cursor para Hand
                                Cursor.Current = Cursors.Hand;
                            }
                        }
                        else
                        {
                            //Define o cursor para default
                            Cursor.Current = Cursors.Default;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
