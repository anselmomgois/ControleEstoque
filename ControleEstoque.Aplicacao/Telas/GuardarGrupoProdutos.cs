using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarGrupoProdutos : TelaBase.BaseCE
    {
        public GuardarGrupoProdutos(string IdentificadorGrupo, Boolean TelaPai, Comum.Clases.GrupoProduto objProdutoGrupoCarregar)
        {
            InitializeComponent();

            _IdentificadorGrupo = IdentificadorGrupo;
            _TelaPai = TelaPai;
            _objProdutoGrupoCarregar = objProdutoGrupoCarregar;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnInserir = "btnInserir";
        private const string btnCancelar = "btnCancelar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorGrupo;
        private Comum.Clases.GrupoProduto _objProdutoGrupo;
        private Comum.Clases.GrupoProduto _objProdutoGrupoCarregar;
        private Boolean _TelaPai;
        private Boolean _FecharJanela = true;

        #endregion

        #region"Propriedades"

        public Comum.Clases.GrupoProduto objGrupoProduto
        {
            get
            {
                return _objProdutoGrupo;
            }
        }

        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir SubGrupo (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(null, null, null, null, "Sair (F11)", btnCancelar, Properties.Resources.exit, new EventHandler(btnCancelar_Click), Keys.F11, false, false, false);
            base.MontarMenu(GerarGrupo, false);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(gpbSubGrupos);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarProdutoCategoria();
            PreencherControles();
        }

        private void RecuperarProdutoCategoria()
        {

            if (!string.IsNullOrEmpty(_IdentificadorGrupo))
            {
                _objProdutoGrupo = LogicaNegocio.GrupoProduto.RecuperarGrupoProduto(_IdentificadorGrupo, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);

            }
            else
            {
                _objProdutoGrupo = new Comum.Clases.GrupoProduto { IdentificadorProvisorio = Convert.ToString(Guid.NewGuid()) };
            }

            if (_objProdutoGrupoCarregar != null)
            {
                _objProdutoGrupo = _objProdutoGrupoCarregar;
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoGrupo != null)
            {

                txtNome.Text = _objProdutoGrupo.Descricao;
                PreencherGrid();
            }
        }

        private void PreencherGrid()
        {
            dgvGrupoProduto.Rows.Clear();

            if (_objProdutoGrupo != null && _objProdutoGrupo.SubGrupos != null && _objProdutoGrupo.SubGrupos.Count > 0)
            {

                foreach (Comum.Clases.GrupoProduto gp in _objProdutoGrupo.SubGrupos)
                {

                    gp.IdentificadorProvisorio = Convert.ToString(Guid.NewGuid());

                    if (!gp.Deletar)
                    {
                        dgvGrupoProduto.Rows.Add();
                        dgvGrupoProduto.Rows[dgvGrupoProduto.Rows.Count - 1].Cells[colIdentificadorProvisorio.Index].Value = gp.IdentificadorProvisorio;
                        dgvGrupoProduto.Rows[dgvGrupoProduto.Rows.Count - 1].Cells[colDescricao.Index].Value = gp.Descricao;
                        dgvGrupoProduto.Rows[dgvGrupoProduto.Rows.Count - 1].Cells[colIdCor.Index].Value = gp.Identificador;
                    }
                }
            }
        }

        private void ExecutarGravar()
        {
            if (_objProdutoGrupo == null) _objProdutoGrupo = new Comum.Clases.GrupoProduto();

            _objProdutoGrupo.Descricao = txtNome.Text.Trim();
            _objProdutoGrupo.Identificador = _IdentificadorGrupo;

            if (_TelaPai)
            {
                if (string.IsNullOrEmpty(_IdentificadorGrupo))
                {
                    LogicaNegocio.GrupoProduto.InserirGrupoProduto(_objProdutoGrupo, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                    ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
                }
                else
                {
                    LogicaNegocio.GrupoProduto.AtualizarGrupoProduto(_objProdutoGrupo, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                     ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
                }

                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);

            }

            _FecharJanela = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        private void dgvGrupoProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGrupoProduto.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                Comum.Clases.GrupoProduto objGrupoCarregar = (from Comum.Clases.GrupoProduto gp in _objProdutoGrupo.SubGrupos
                                                                              where gp.IdentificadorProvisorio == dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string
                                                                              select gp).FirstOrDefault();

                                GuardarGrupoProdutos frmGrupo = new GuardarGrupoProdutos(dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, false, objGrupoCarregar);

                                if (frmGrupo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {

                                    if (frmGrupo.objGrupoProduto != null && !string.IsNullOrEmpty(frmGrupo.objGrupoProduto.Identificador))
                                    {

                                        Comum.Clases.GrupoProduto objGrupo = (from Comum.Clases.GrupoProduto gp in _objProdutoGrupo.SubGrupos
                                                                              where gp.Identificador == frmGrupo.objGrupoProduto.Identificador
                                                                              select gp).FirstOrDefault();
                                        objGrupo = frmGrupo.objGrupoProduto;
                                        PreencherGrid();
                                    }


                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                if (MessageBox.Show("Deseja deletar o sub-grupo?", "CE - CONTROLE DE ESTOQUE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                
                                {
                                    if (_objProdutoGrupo != null && _objProdutoGrupo.SubGrupos != null && _objProdutoGrupo.SubGrupos.Count > 0)
                                    {
                                        if (string.IsNullOrEmpty(_IdentificadorGrupo))
                                        {
                                            _objProdutoGrupo.SubGrupos.RemoveAll(f => f.IdentificadorProvisorio == dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string);
                                        }
                                        else
                                        {
                                            if (!LogicaNegocio.GrupoProduto.GrupoEstaSendoUsado(dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login))
                                            {
                                                _objProdutoGrupo.SubGrupos.FindAll(f => f.IdentificadorProvisorio == dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string).FirstOrDefault().Deletar = true;
                                            }
                                            else
                                            {
                                                Aplicacao.Classes.Util.ExibirMensagemErro("Existem produtos que estão utilizando este grupo.");
                                                return;
                                            }
                                        }

                                        PreencherGrid();
                                    }
                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvGrupoProduto_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvGrupoProduto.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {
                            //Define o cursor para Hand
                            Cursor.Current = Cursors.Hand;
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                _FecharJanela = false;
                GuardarGrupoProdutos frmGrupo = new GuardarGrupoProdutos(string.Empty, false, null);
                frmGrupo.Owner = this;

                if (frmGrupo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (frmGrupo.objGrupoProduto != null)
                    {

                        if (_objProdutoGrupo == null) _objProdutoGrupo = new Comum.Clases.GrupoProduto();
                        if (_objProdutoGrupo.SubGrupos == null) _objProdutoGrupo.SubGrupos = new List<Comum.Clases.GrupoProduto>();
                        _objProdutoGrupo.SubGrupos.Add(frmGrupo.objGrupoProduto);
                        PreencherGrid();
                    }


                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        
        private void GuardarGrupoProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_FecharJanela)
            {
                e.Cancel = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

                _FecharJanela = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

    }
}
