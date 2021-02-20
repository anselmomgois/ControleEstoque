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
    public partial class GuardarEmpresa : TelaBase.BaseCE
    {
        public GuardarEmpresa()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private Comum.Clases.Empresa objEmpresa;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnInserirFilial = "btnInserirFilial";
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir Filial (F3)", btnInserirFilial, Properties.Resources._new, new EventHandler(btnInserirFilial_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbDadosEmpresa);
            CarregarTela();
            base.Inicializar();
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                base.RespostaAgente(objSaida, operacao, Parametros);

                if (operacao == SDK.Operacoes.operacao.CarregarGuardarEmpresa)
                {
                    ContratoServico.Telas.GuardarEmpresa.Carregar.RespostaGuardarEmpresaCarregar objRespostaConvertido = (ContratoServico.Telas.GuardarEmpresa.Carregar.RespostaGuardarEmpresaCarregar)objSaida;

                    objEmpresa = objRespostaConvertido.Empresa;

                    PreencherControles();
                    ConfigurarVisualizacaoTela();

                }
                else if(operacao == SDK.Operacoes.operacao.AtualizarEmpresa)
                {
                    base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void CarregarTela()
        {

            RecuperarEmpresa();
           
        }

        private void PreencherControles()
        {

            txtNome.Text = objEmpresa.Nome;
            txtCnpj.Text = objEmpresa.Cnpj;
            txtInscricao.Text = objEmpresa.InscricaoEstadual;
            txtEmail.Text = objEmpresa.Email;
            txtSenha.Text = objEmpresa.Senha;
            txtsmtp.Text = objEmpresa.Smtp;
            txtPorta.Text = objEmpresa.Porta != null ? Convert.ToString(objEmpresa.Porta) : null;
            chkSSl.Checked = objEmpresa.Ssl;
            PreencherFiliais();
        }

        private void ConfigurarVisualizacaoTela()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_EMPRESA, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserirFilial, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_EMPRESA, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_EMPRESA, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;

            }


            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_EMPRESA, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
            {
                colVisualizar.Visible = false;

            }
            else if (!colEditar.Visible)
            {
                txtCnpj.Enabled = false;
                txtInscricao.Enabled = false;
                txtNome.Enabled = false;
            }

        }

        private void PreencherFiliais()
        {

            if (objEmpresa.Filiais != null && objEmpresa.Filiais.Count > 0)
            {

                dgvEmpresa.Rows.Clear();

                foreach (Comum.Clases.Filiais Filial in objEmpresa.Filiais)
                {
                    Filial.IdentificadorProvisorio = Convert.ToString(Guid.NewGuid());

                    dgvEmpresa.Rows.Add();
                    dgvEmpresa.Rows[dgvEmpresa.Rows.Count - 1].Cells[colIdentificadorProvisorio.Index].Value = Filial.IdentificadorProvisorio;
                    dgvEmpresa.Rows[dgvEmpresa.Rows.Count - 1].Cells[colIdentificador.Index].Value = Filial.Identificador;
                    dgvEmpresa.Rows[dgvEmpresa.Rows.Count - 1].Cells[colFilial.Index].Value = Filial.Nome;
                    dgvEmpresa.Rows[dgvEmpresa.Rows.Count - 1].Cells[colEmail.Index].Value = Filial.Email;
                    dgvEmpresa.Rows[dgvEmpresa.Rows.Count - 1].Cells[colTelefone.Index].Value = Filial.TelefoneFixo;

                    if (Filial.Apagar || !Filial.Ativa)
                    {
                        dgvEmpresa.Rows[dgvEmpresa.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                    }

                }
            }

        }

        private void RecuperarEmpresa()
        {

            ContratoServico.Telas.GuardarEmpresa.Carregar.PeticaoGuardarEmpresaCarregar Peticao = new ContratoServico.Telas.GuardarEmpresa.Carregar.PeticaoGuardarEmpresaCarregar()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarEmpresa.Carregar.RespostaGuardarEmpresaCarregar, ContratoServico.Telas.GuardarEmpresa.Carregar.PeticaoGuardarEmpresaCarregar>(Peticao,
                  SDK.Operacoes.operacao.CarregarGuardarEmpresa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        private void ExecutarGravar()
        {

            objEmpresa.Nome = txtNome.Text.Trim();
            objEmpresa.InscricaoEstadual = txtInscricao.Text;
            
            if (!string.IsNullOrEmpty(txtCnpj.Text.Replace(",", "").Replace("/", "").Replace("-", "").Trim()))
            {
                objEmpresa.Cnpj = txtCnpj.Text;
            }
            else
            {
                objEmpresa.Cnpj = string.Empty;
            }

            objEmpresa.Email = txtEmail.Text;
            objEmpresa.Senha = txtSenha.Text;
            objEmpresa.Smtp = txtsmtp.Text;
            objEmpresa.Ssl = chkSSl.Checked;
            objEmpresa.Porta = !string.IsNullOrEmpty(txtPorta.Text) ? Convert.ToInt32(txtPorta.Text) : 0;

            ContratoServico.Empresa.AtualizarEmpresa.PeticaoAtualizarEmpresa Peticao = new ContratoServico.Empresa.AtualizarEmpresa.PeticaoAtualizarEmpresa()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Empresa = objEmpresa
            };

            Agente.Agente.InvocarServico<ContratoServico.Empresa.AtualizarEmpresa.RespostaAtualizarEmpresa, ContratoServico.Empresa.AtualizarEmpresa.PeticaoAtualizarEmpresa>(Peticao,
                  SDK.Operacoes.operacao.AtualizarEmpresa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                                 

        }

        #endregion

        #region "Eventos"

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void btnInserirFilial_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarFilial frmFilial = new GuardarFilial(null, false);

                if (frmFilial.ShowDialog() == System.Windows.Forms.DialogResult.OK && frmFilial.FilialSalva != null)
                {
                    objEmpresa.Filiais.Add(frmFilial.FilialSalva);
                    PreencherFiliais();
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void dgvEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEmpresa.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colVisualizar.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colVisualizar.Index)
                            {

                                Comum.Clases.Filiais objFilialSelecionada = (from Comum.Clases.Filiais objF in objEmpresa.Filiais
                                                                             where objF.IdentificadorProvisorio == dgvEmpresa.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string
                                                                             select objF).FirstOrDefault();

                                GuardarFilial frmFilial = new GuardarFilial(objFilialSelecionada, (e.ColumnIndex == colVisualizar.Index));

                                if (frmFilial.ShowDialog() == System.Windows.Forms.DialogResult.OK && frmFilial.FilialSalva != null)
                                {
                                    if (objEmpresa.Filiais.FindAll(f => f.IdentificadorProvisorio == frmFilial.FilialSalva.IdentificadorProvisorio).Count == 0)
                                    {
                                        objEmpresa.Filiais.Add(frmFilial.FilialSalva);
                                    }
                                    PreencherFiliais();
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {


                                Comum.Clases.Filiais objFilialSelecionada = (from Comum.Clases.Filiais objF in objEmpresa.Filiais
                                                                             where objF.IdentificadorProvisorio == dgvEmpresa.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string
                                                                             select objF).FirstOrDefault();

                                if (objFilialSelecionada != null)
                                {
                                    objFilialSelecionada.Apagar = true;
                                    PreencherFiliais();
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

        private void dgvEmpresa_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (dgvEmpresa.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colVisualizar.Index)
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

        private void txtPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion
    }
}
