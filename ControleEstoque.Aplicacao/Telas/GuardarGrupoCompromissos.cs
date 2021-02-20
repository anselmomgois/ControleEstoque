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
    public partial class GuardarGrupoCompromissos : TelaBase.BaseCE
    {
        public GuardarGrupoCompromissos(string IdentificadorGrupo, Boolean TelaPai, Comum.Clases.GrupoCompromisso objGrupoCompromissoCarregar)
        {
            InitializeComponent();

            _IdentificadorGrupo = IdentificadorGrupo;
            _TelaPai = TelaPai;
            _objGrupoCompromissoCarregar = objGrupoCompromissoCarregar;
        }

        #region"Variaveis"

        private string _IdentificadorGrupo;
        private Comum.Clases.GrupoCompromisso _objGrupoCompromisso;
        private Comum.Clases.GrupoCompromisso _objGrupoCompromissoCarregar;
        private Boolean _TelaPai;
        private Boolean _FecharJanela = true;
        private List<Comum.Clases.Pergunta> _objPerguntas;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnInserir = "btnInserir";
        private const string btnCancelar = "btnCancelar";
        #endregion

        #region"Propriedades"

        public Comum.Clases.GrupoCompromisso objGrupoCompromisso
        {
            get
            {
                return _objGrupoCompromisso;
            }
        }

        #endregion

        #region "Metodos"

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarGrupoCompromisso)
            {
                _objGrupoCompromisso = ((ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.RespostaRecuperarGrupoCompromisso)objSaida).GrupoCompromisso;

                if (_objGrupoCompromissoCarregar != null)
                {
                    _objGrupoCompromisso = _objGrupoCompromissoCarregar;
                }

                PreencherControles();

            }
            else if(operacao == SDK.Operacoes.operacao.SetGrupoCompromisso)
            {
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);

                _FecharJanela = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }


        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir SubGrupo (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(null, null, null, null,"Sair (F11)", btnCancelar,  Properties.Resources.exit, new EventHandler(btnCancelar_Click), Keys.F11, false, false, false);
            base.MontarMenu(GerarGrupo,false);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(gpbPerguntas);
            this.pnlBase.Controls.Add(gpbSubGrupos);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarGrupoCompromissos();
            
        }

        private void CarregarGridPerguntas()
        {

            dgvPerguntas.Rows.Clear();

            if (_objPerguntas != null && _objPerguntas.Count > 0)
            {

                foreach (Comum.Clases.Pergunta objProp in _objPerguntas)
                {

                    if (!objProp.Deletar)
                    {
                        dgvPerguntas.Rows.Add();
                        objProp.IdentificadorAuxiliar = Guid.NewGuid().ToString();
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colIdentificadorPerguntaProv.Index].Value = objProp.IdentificadorAuxiliar;
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colIdentificador.Index].Value = objProp.Identificador;
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colPergunta.Index].Value = objProp.DesPergunta;
                    }
                }
            }



            dgvPerguntas.Rows.Add();
            dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colEditarPergunta.Index].Value = Properties.Resources.fundo_branco;
            dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colExcluirPergunta.Index].Value = Properties.Resources._new;
            
        }

        private void RecuperarGrupoCompromissos()
        {

            if (!string.IsNullOrEmpty(_IdentificadorGrupo))
            {
                ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.PeticaoRecuperarGrupoCompromisso Peticao = new ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.PeticaoRecuperarGrupoCompromisso()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorGrupoCompromisso = _IdentificadorGrupo
                };

                Agente.Agente.InvocarServico<ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.RespostaRecuperarGrupoCompromisso, ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.PeticaoRecuperarGrupoCompromisso>(Peticao,
                      SDK.Operacoes.operacao.RecuperarGrupoCompromisso, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

            }
            else
            {
                _objGrupoCompromisso = new Comum.Clases.GrupoCompromisso { IdentificadorProvisorio = Convert.ToString(Guid.NewGuid()) };

                if (_objGrupoCompromissoCarregar != null)
                {
                    _objGrupoCompromisso = _objGrupoCompromissoCarregar;
                }

                PreencherControles();

            }            

        }

        private void PreencherControles()
        {

            if (_objGrupoCompromisso != null)
            {

                txtNome.Text = _objGrupoCompromisso.Descricao;

                if (_objGrupoCompromisso.Perguntas != null && _objGrupoCompromisso.Perguntas.Count > 0)
                {
                    _objPerguntas = _objGrupoCompromisso.Perguntas;
                }

                PreencherGrid();
                
            }
            else
            {
                _objPerguntas = new List<Comum.Clases.Pergunta>();
            }

            CarregarGridPerguntas();
        }

        private void PreencherGrid()
        {
            dgvGrupoProduto.Rows.Clear();

            if (_objGrupoCompromisso != null && _objGrupoCompromisso.SubGrupos != null && _objGrupoCompromisso.SubGrupos.Count > 0)
            {

                foreach (Comum.Clases.GrupoCompromisso gp in _objGrupoCompromisso.SubGrupos)
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
            if (_objGrupoCompromisso == null) _objGrupoCompromisso = new Comum.Clases.GrupoCompromisso();

            _objGrupoCompromisso.Descricao = txtNome.Text.Trim();
            _objGrupoCompromisso.Identificador = _IdentificadorGrupo;
            _objGrupoCompromisso.Perguntas = _objPerguntas;

            if (_TelaPai)
            {

                ContratoServico.GrupoCompromisso.SetGrupoCompromisso.PeticaoSetGrupoCompromisso Peticao = new ContratoServico.GrupoCompromisso.SetGrupoCompromisso.PeticaoSetGrupoCompromisso()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    GrupoCompromisso = _objGrupoCompromisso,
                    IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
                };

                Agente.Agente.InvocarServico<ContratoServico.GrupoCompromisso.SetGrupoCompromisso.RespostaSetGrupoCompromisso, ContratoServico.GrupoCompromisso.SetGrupoCompromisso.PeticaoSetGrupoCompromisso>(Peticao,
                      SDK.Operacoes.operacao.SetGrupoCompromisso, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);               
                

            }
            else
            {

                _FecharJanela = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

            
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            if (NomeGrid == "dgvGrupoProduto")
            {

                if (RowIndex != dgvPerguntas.Rows.Count - 1)
                {

                    Comum.Clases.GrupoCompromisso objGrupoCarregar = (from Comum.Clases.GrupoCompromisso gp in _objGrupoCompromisso.SubGrupos
                                                                      where gp.IdentificadorProvisorio == Identificador.Value
                                                                      select gp).FirstOrDefault();

                    GuardarGrupoCompromissos frmGrupo = new GuardarGrupoCompromissos(Identificador.Value, false, objGrupoCarregar);
                    if (frmGrupo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        if (frmGrupo.objGrupoCompromisso != null && !string.IsNullOrEmpty(frmGrupo.objGrupoCompromisso.Identificador))
                        {

                            Comum.Clases.GrupoCompromisso objGrupo = (from Comum.Clases.GrupoCompromisso gp in _objGrupoCompromisso.SubGrupos
                                                                      where gp.Identificador == frmGrupo._objGrupoCompromisso.Identificador
                                                                      select gp).FirstOrDefault();
                            objGrupo = frmGrupo.objGrupoCompromisso;
                            PreencherGrid();
                        }


                    }
                }
            }
            else
            {
                if(RowIndex != dgvPerguntas.Rows.Count - 1)
                {
                    Comum.Clases.Pergunta objPergAux = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                        where objP.IdentificadorAuxiliar == Identificador.Value
                                                        select objP).FirstOrDefault();

                    GuardarPergunta frmPergunta = new GuardarPergunta(objPergAux);

                    if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frmPergunta.objPerguntaTrans != null)
                        {
                            if (_objPerguntas == null) _objPerguntas = new List<Comum.Clases.Pergunta>();

                            Comum.Clases.Pergunta objPerg = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                             where objP.IdentificadorAuxiliar == frmPergunta.objPerguntaTrans.IdentificadorAuxiliar
                                                             select objP).FirstOrDefault();

                            if (objPerg != null)
                            {
                                objPerg.DesPergunta = frmPergunta.objPerguntaTrans.DesPergunta;
                                objPerg.Numerico = frmPergunta.objPerguntaTrans.Numerico;
                                objPerg.Obrigatoria = frmPergunta.objPerguntaTrans.Obrigatoria;
                                objPerg.Opcoes = frmPergunta.objPerguntaTrans.Opcoes;
                            }
                            else
                            {
                                _objPerguntas.Add(frmPergunta.objPerguntaTrans);
                            }

                            CarregarGridPerguntas();
                        }
                    }
                }

            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            if (NomeGrid == "dgvGrupoProduto")
            {

                if (MessageBox.Show("Deseja deletar o sub-grupo?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (_objGrupoCompromisso != null && _objGrupoCompromisso.SubGrupos != null && _objGrupoCompromisso.SubGrupos.Count > 0)
                    {
                        if (string.IsNullOrEmpty(_IdentificadorGrupo))
                        {
                            _objGrupoCompromisso.SubGrupos.RemoveAll(f => f.IdentificadorProvisorio == Identificador.Value);
                        }
                        else
                        {
                             _objGrupoCompromisso.SubGrupos.FindAll(f => f.IdentificadorProvisorio == Identificador.Value).FirstOrDefault().Deletar = true;                            
                        }

                        PreencherGrid();
                    }
                }
            }
            else
            {
                if (_objPerguntas.Count > 0 &&  RowIndex != dgvPerguntas.Rows.Count - 1 && 
                    MessageBox.Show("Deseja deletar a pergunta?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Comum.Clases.Pergunta objPerg = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                     where objP.IdentificadorAuxiliar == Identificador.Value
                                                     select objP).FirstOrDefault();

                    if (objPerg != null)
                    {
                        objPerg.Deletar = true;
                        CarregarGridPerguntas();
                    }
                }
            }

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Inserir(string NomeGrid)
        {

            if (NomeGrid == "dgvPerguntas")
            {

                GuardarPergunta frmPergunta = new GuardarPergunta(null);

                if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmPergunta.objPerguntaTrans != null)
                    {
                        if (_objPerguntas == null) _objPerguntas = new List<Comum.Clases.Pergunta>();

                        Comum.Clases.Pergunta objPerg = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                         where objP.IdentificadorAuxiliar == frmPergunta.objPerguntaTrans.IdentificadorAuxiliar
                                                         select objP).FirstOrDefault();

                        if (objPerg != null)
                        {
                            objPerg.DesPergunta = frmPergunta.objPerguntaTrans.DesPergunta;
                            objPerg.Numerico = frmPergunta.objPerguntaTrans.Numerico;
                            objPerg.Obrigatoria = frmPergunta.objPerguntaTrans.Obrigatoria;
                            objPerg.Opcoes = frmPergunta.objPerguntaTrans.Opcoes;
                        }
                        else
                        {
                            _objPerguntas.Add(frmPergunta.objPerguntaTrans);
                        }

                        CarregarGridPerguntas();
                    }
                }
            }

            base.Inserir(NomeGrid);
        }
        #endregion

        #region "Eventos"
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
                GuardarGrupoCompromissos frmGrupo = new GuardarGrupoCompromissos(string.Empty, false, null);
                frmGrupo.Owner = this;

                if (frmGrupo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (frmGrupo.objGrupoCompromisso != null)
                    {

                        if (_objGrupoCompromisso == null) _objGrupoCompromisso = new Comum.Clases.GrupoCompromisso();
                        if (_objGrupoCompromisso.SubGrupos == null) _objGrupoCompromisso.SubGrupos = new List<Comum.Clases.GrupoCompromisso>();
                        _objGrupoCompromisso.SubGrupos.Add(frmGrupo.objGrupoCompromisso);
                        PreencherGrid();
                    }


                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
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

        private void GuardarGrupoCompromissos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_FecharJanela)
            {
                e.Cancel = true;
            }
        }

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

                                Comum.Clases.GrupoCompromisso objGrupoCarregar = (from Comum.Clases.GrupoCompromisso gp in _objGrupoCompromisso.SubGrupos
                                                                              where gp.IdentificadorProvisorio == dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string
                                                                              select gp).FirstOrDefault();

                                GuardarGrupoCompromissos frmGrupo = new GuardarGrupoCompromissos(dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, false, objGrupoCarregar);
                                if (frmGrupo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {

                                    if (frmGrupo.objGrupoCompromisso != null && !string.IsNullOrEmpty(frmGrupo.objGrupoCompromisso.Identificador))
                                    {

                                        Comum.Clases.GrupoCompromisso objGrupo = (from Comum.Clases.GrupoCompromisso gp in _objGrupoCompromisso.SubGrupos
                                                                                  where gp.Identificador == frmGrupo._objGrupoCompromisso.Identificador
                                                                              select gp).FirstOrDefault();
                                        objGrupo = frmGrupo.objGrupoCompromisso;
                                        PreencherGrid();
                                    }


                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                if (MessageBox.Show("Deseja deletar o sub-grupo?", "CE - CONTROLE DE ESTOQUE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    if (_objGrupoCompromisso != null && _objGrupoCompromisso.SubGrupos != null && _objGrupoCompromisso.SubGrupos.Count > 0)
                                    {
                                        if (string.IsNullOrEmpty(_IdentificadorGrupo))
                                        {
                                            _objGrupoCompromisso.SubGrupos.RemoveAll(f => f.IdentificadorProvisorio == dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string);
                                        }
                                        else
                                        {
                                           _objGrupoCompromisso.SubGrupos.FindAll(f => f.IdentificadorProvisorio == dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdentificadorProvisorio.Index].Value as string).FirstOrDefault().Deletar = true;                                           
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

                                    GuardarPergunta frmPergunta = new GuardarPergunta(null);

                                    if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (frmPergunta.objPerguntaTrans != null)
                                        {
                                            if (_objPerguntas == null) _objPerguntas = new List<Comum.Clases.Pergunta>();

                                            Comum.Clases.Pergunta objPerg = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                                             where objP.IdentificadorAuxiliar == frmPergunta.objPerguntaTrans.IdentificadorAuxiliar
                                                                             select objP).FirstOrDefault();

                                            if (objPerg != null)
                                            {
                                                objPerg.DesPergunta = frmPergunta.objPerguntaTrans.DesPergunta;
                                                objPerg.Numerico = frmPergunta.objPerguntaTrans.Numerico;
                                                objPerg.Obrigatoria = frmPergunta.objPerguntaTrans.Obrigatoria;
                                                objPerg.Opcoes = frmPergunta.objPerguntaTrans.Opcoes;
                                            }
                                            else
                                            {
                                                _objPerguntas.Add(frmPergunta.objPerguntaTrans);
                                            }

                                            CarregarGridPerguntas();
                                        }
                                    }
                                }
                                else
                                {
                                    if (_objPerguntas.Count > 0)
                                    {
                                        Comum.Clases.Pergunta objPerg = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                                         where objP.IdentificadorAuxiliar == dgvPerguntas.Rows[e.RowIndex].Cells[colIdentificadorPerguntaProv.Index].Value
                                                                         select objP).FirstOrDefault();

                                        if (objPerg != null)
                                        {
                                            objPerg.Deletar = true;
                                            CarregarGridPerguntas();
                                        }
                                    }

                                }
                            }
                            else
                            {

                                Comum.Clases.Pergunta objPergAux = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                                    where objP.IdentificadorAuxiliar == dgvPerguntas.Rows[e.RowIndex].Cells[colIdentificadorPerguntaProv.Index].Value
                                                                    select objP).FirstOrDefault();

                                GuardarPergunta frmPergunta = new GuardarPergunta(objPergAux);

                                if (frmPergunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frmPergunta.objPerguntaTrans != null)
                                    {
                                        if (_objPerguntas == null) _objPerguntas = new List<Comum.Clases.Pergunta>();

                                        Comum.Clases.Pergunta objPerg = (from Comum.Clases.Pergunta objP in _objPerguntas
                                                                         where objP.IdentificadorAuxiliar == frmPergunta.objPerguntaTrans.IdentificadorAuxiliar
                                                                         select objP).FirstOrDefault();

                                        if (objPerg != null)
                                        {
                                            objPerg.DesPergunta = frmPergunta.objPerguntaTrans.DesPergunta;
                                            objPerg.Numerico = frmPergunta.objPerguntaTrans.Numerico;
                                            objPerg.Obrigatoria = frmPergunta.objPerguntaTrans.Obrigatoria;
                                            objPerg.Opcoes = frmPergunta.objPerguntaTrans.Opcoes;
                                        }
                                        else
                                        {
                                            _objPerguntas.Add(frmPergunta.objPerguntaTrans);
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
               
        #endregion
    }
}
