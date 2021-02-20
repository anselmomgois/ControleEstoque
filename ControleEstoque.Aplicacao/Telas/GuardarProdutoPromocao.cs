using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoPromocao : TelaBase.BaseCE
    {
        public GuardarProdutoPromocao(string IdentificadorProdutoPromocao, Boolean Bloquear)
        {
            InitializeComponent();

            _IdentificadorProdutoPromocao = IdentificadorProdutoPromocao;
            _Bloquear = Bloquear;
        }

        #region"Variaveis"

        private Comum.Clases.ProdutosGeral objProdutosGeral;
        private CurrencyTextBox CurrencyTextBox;
        private string _IdentificadorProdutoPromocao;
        private Comum.Clases.ProdutoPromocao _objProdutoPromocao;
        private Boolean _Bloquear;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
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
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            CarregarTela();
            base.Inicializar();
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);
            BloquearControles();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarProdutoPromocao)
            {
                ContratoServico.Telas.GuardarProdutoPromocao.Carregar.RespostaGuardarProdutoPromocaoCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarProdutoPromocao.Carregar.RespostaGuardarProdutoPromocaoCarregar)objSaida;

                objProdutosGeral = objSaidaConvertido.ProdutosGeral;
                _objProdutoPromocao = objSaidaConvertido.ProdutoPromocao;

                PreencherGridsProduto();
                PreencherControles();
                HabilitarCombo();
                BloquearControles();

            }
            else if (operacao == SDK.Operacoes.operacao.SetProdutoPromocao)
            {

                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void PreencherGridsProduto()
        {

            if (objProdutosGeral != null)
            {

                if (objProdutosGeral.ProdutoFilialEstoque != null && objProdutosGeral.ProdutoFilialEstoque.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pfe in objProdutosGeral.ProdutoFilialEstoque)
                    {

                        dgvProdutosEstoque.Rows.Add();
                        dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Cells[colDescricaoCompras.Index].Value = pfe.Descricao;
                        dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Cells[colIdentificadorCompras.Index].Value = pfe.IdentificadorProdutoCompra;
                        dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Cells[colIdentificadorProdutoFilialC.Index].Value = pfe.IdentificadorProdutoFilial;
                        dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Cells[colIdentificadorProdutoServicoC.Index].Value = pfe.Identificador;
                        dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Cells[colEstoqueCompra.Index].Value = pfe.Estoque;
                        dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Cells[colCodigoBarrasCompras.Index].Value = (pfe.CodigosBarras != null && pfe.CodigosBarras.Count > 0 ? string.Join(Environment.NewLine, pfe.CodigosBarras.Select(cb => cb.CodigoBarras)) : string.Empty);

                        if (pfe.CodigosBarras != null && pfe.CodigosBarras.Count > 1)
                        {
                            dgvProdutosEstoque.Rows[dgvProdutosEstoque.Rows.Count - 1].Height = 20 * pfe.CodigosBarras.Count;
                        }
                    }
                }
                else
                {
                    dgvProdutosEstoque.Enabled = false;
                }

                if (objProdutosGeral.ProdutosFilial != null && objProdutosGeral.ProdutosFilial.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pfe in objProdutosGeral.ProdutosFilial)
                    {

                        dgvProdutosFilial.Rows.Add();
                        dgvProdutosFilial.Rows[dgvProdutosFilial.Rows.Count - 1].Cells[colDescricaoFilial.Index].Value = pfe.Descricao;
                        dgvProdutosFilial.Rows[dgvProdutosFilial.Rows.Count - 1].Cells[colIdentificadorFilial.Index].Value = pfe.IdentificadorProdutoFilial;
                        dgvProdutosFilial.Rows[dgvProdutosFilial.Rows.Count - 1].Cells[colIdentificadorProdutoServicoF.Index].Value = pfe.Identificador;
                        dgvProdutosFilial.Rows[dgvProdutosFilial.Rows.Count - 1].Cells[colEstoqueFilial.Index].Value = pfe.Estoque;
                        dgvProdutosFilial.Rows[dgvProdutosFilial.Rows.Count - 1].Cells[colCodigoBarrasFilial.Index].Value = (pfe.CodigosBarras != null && pfe.CodigosBarras.Count > 0 ? string.Join(Environment.NewLine, pfe.CodigosBarras.Select(cb => cb.CodigoBarras)) : string.Empty);

                        if (pfe.CodigosBarras != null && pfe.CodigosBarras.Count > 1)
                        {
                            dgvProdutosFilial.Rows[dgvProdutosFilial.Rows.Count - 1].Height = 20 * pfe.CodigosBarras.Count;
                        }

                    }
                }
                else
                {
                    dgvProdutosFilial.Enabled = false;
                }

                if (objProdutosGeral.ProdutosEmpresa != null && objProdutosGeral.ProdutosEmpresa.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pfe in objProdutosGeral.ProdutosEmpresa)
                    {

                        dgvProdutoEmpresa.Rows.Add();
                        dgvProdutoEmpresa.Rows[dgvProdutoEmpresa.Rows.Count - 1].Cells[colDescricaoEmpresa.Index].Value = pfe.Descricao;
                        dgvProdutoEmpresa.Rows[dgvProdutoEmpresa.Rows.Count - 1].Cells[colIdentificadorEmpresa.Index].Value = pfe.Identificador;
                        dgvProdutoEmpresa.Rows[dgvProdutoEmpresa.Rows.Count - 1].Cells[colEstoqueEmpresa.Index].Value = pfe.Estoque;
                        dgvProdutoEmpresa.Rows[dgvProdutoEmpresa.Rows.Count - 1].Cells[colCodigoBarrasEmpresa.Index].Value = (pfe.CodigosBarras != null && pfe.CodigosBarras.Count > 0 ? string.Join(Environment.NewLine, pfe.CodigosBarras.Select(cb => cb.CodigoBarras)) : string.Empty);

                        if (pfe.CodigosBarras != null && pfe.CodigosBarras.Count > 1)
                        {
                            dgvProdutoEmpresa.Rows[dgvProdutoEmpresa.Rows.Count - 1].Height = 20 * pfe.CodigosBarras.Count;
                        }

                    }
                }
                else
                {
                    dgvProdutoEmpresa.Enabled = false;
                }
            }
        }

        private void PreencherControles()
        {

            if (!string.IsNullOrEmpty(_IdentificadorProdutoPromocao))
            {

                txtNome.Text = _objProdutoPromocao.Descricao;

                if (_objProdutoPromocao.PercentualDesconto != null)
                {
                    txtPercentual.Text = Convert.ToString(_objProdutoPromocao.PercentualDesconto);
                }

                if (_objProdutoPromocao.Valor != null)
                {
                    txtValorDesconto.Text = Convert.ToString(_objProdutoPromocao.Valor);
                }

                dtpInicio.Value = _objProdutoPromocao.DataInicio;

                if (_objProdutoPromocao.DataFim != null)
                {
                    dtpFim.Value = Convert.ToDateTime(_objProdutoPromocao.DataFim);
                }

                chkHabilitada.Checked = _objProdutoPromocao.Habilitada;

                switch (_objProdutoPromocao.CodigoTipoPromocao)
                {

                    case Comum.Clases.Constantes.COD_TIPO_PROMOCAO_EMPRESA:

                        rbnEmpresa.Checked = true;

                        if (_objProdutoPromocao.PrudutosEmpresa != null && _objProdutoPromocao.PrudutosEmpresa.Count > 0 &&
                            dgvProdutoEmpresa != null && dgvProdutoEmpresa.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow dr in dgvProdutoEmpresa.Rows)
                            {


                                if ((from Comum.Clases.ProdutoServico ps in _objProdutoPromocao.PrudutosEmpresa
                                     where ps.Identificador.Equals(dr.Cells[colIdentificadorEmpresa.Index].Value)
                                     select ps).Count() > 0)
                                {
                                    dr.Cells[colSelecionarEmpresa.Index].Value = true;
                                }

                            }
                        }

                        break;
                    case Comum.Clases.Constantes.COD_TIPO_PROMOCAO_ESTOQUE:

                        rbnEstoque.Checked = true;

                        if (_objProdutoPromocao.ProdutosCompra != null && _objProdutoPromocao.ProdutosCompra.Count > 0 &&
                           dgvProdutosEstoque != null && dgvProdutosEstoque.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow dr in dgvProdutosEstoque.Rows)
                            {


                                if ((from Comum.Clases.ProdutoServico ps in _objProdutoPromocao.ProdutosCompra
                                     where ps.IdentificadorProdutoCompra.Equals(dr.Cells[colIdentificadorCompras.Index].Value)
                                     select ps).Count() > 0)
                                {
                                    dr.Cells[colSelecionarCompras.Index].Value = true;
                                }

                            }
                        }

                        break;
                    case Comum.Clases.Constantes.COD_TIPO_PROMOCAO_FILIAL:

                        rbnFilial.Checked = true;

                        if (_objProdutoPromocao.ProdutosPorFilial != null && _objProdutoPromocao.ProdutosPorFilial.Count > 0 &&
                          dgvProdutosFilial != null && dgvProdutosFilial.Rows.Count > 0)
                        {

                            foreach (DataGridViewRow dr in dgvProdutosFilial.Rows)
                            {


                                if ((from Comum.Clases.ProdutoServico ps in _objProdutoPromocao.ProdutosPorFilial
                                     where ps.IdentificadorProdutoFilial.Equals(dr.Cells[colIdentificadorFilial.Index].Value)
                                     select ps).Count() > 0)
                                {
                                    dr.Cells[colSelecionarFilial.Index].Value = true;
                                }

                            }
                        }

                        break;

                }
                chkPorHorario.Checked = _objProdutoPromocao.PorHorario;

                if (_objProdutoPromocao.DiasSemana != null && _objProdutoPromocao.DiasSemana.Count > 0)
                {
                    foreach (Comum.Enumeradores.Enumeradores.DiasSemana ds in _objProdutoPromocao.DiasSemana)
                    {
                        var i = 0;
                        foreach (string item in chklistadiassemana.Items)
                        {
                            if (ds.ToString() == item)
                            {
                                chklistadiassemana.SetItemCheckState(i, CheckState.Checked);
                                break;
                            }
                            i++;
                        }
                    }
                }
            }
            else
            {
                chkHabilitada.Checked = true;
                chkHabilitada.Enabled = false;
            }
        }

        private void CarregarTela()
        {

            chklistadiassemana.Items.Clear();

            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Domingo.ToString());
            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Segunda.ToString());
            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Terça.ToString());
            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Quarta.ToString());
            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Quinta.ToString());
            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Sexta.ToString());
            chklistadiassemana.Items.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Sábado.ToString());

            ContratoServico.Telas.GuardarProdutoPromocao.Carregar.PeticaoGuardarProdutoPromocaoCarregar Peticao = new ContratoServico.Telas.GuardarProdutoPromocao.Carregar.PeticaoGuardarProdutoPromocaoCarregar();

            Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.First().Identificador;
            Peticao.IdentificadorProdutoPromocao = _IdentificadorProdutoPromocao;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarProdutoPromocao.Carregar.RespostaGuardarProdutoPromocaoCarregar, ContratoServico.Telas.GuardarProdutoPromocao.Carregar.PeticaoGuardarProdutoPromocaoCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarProdutoPromocao,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);

        }

        private void BloquearControles()
        {

            if (_Bloquear)
            {
                txtNome.Enabled = false;
                txtPercentual.Enabled = false;
                txtValorDesconto.Enabled = false;
                rbnEmpresa.Enabled = false;
                rbnEstoque.Enabled = false;
                rbnFilial.Enabled = false;
                chkHabilitada.Enabled = false;
                chkPorHorario.Enabled = false;
                chklistadiassemana.Enabled = false;
                dtpFim.Enabled = false;
                dtpInicio.Enabled = false;
                dgvProdutoEmpresa.Enabled = false;
                dgvProdutosEstoque.Enabled = false;
                dgvProdutosFilial.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);

                DesmarcarGrids(ref dgvProdutosFilial, false);
                DesmarcarGrids(ref dgvProdutosEstoque, false);
                DesmarcarGrids(ref dgvProdutoEmpresa, false);


            }
        }
        private void HabilitarCombo()
        {

            if (_objProdutoPromocao == null)
            {
                if (objProdutosGeral != null)
                {

                    if (objProdutosGeral.ProdutosEmpresa == null || objProdutosGeral.ProdutosEmpresa.Count == 0)
                    {
                        rbnEmpresa.Enabled = false;
                    }
                    else
                    {
                        rbnEmpresa.Checked = true;
                    }

                    if (objProdutosGeral.ProdutosFilial == null || objProdutosGeral.ProdutosFilial.Count == 0)
                    {
                        rbnFilial.Enabled = false;
                    }

                    if (objProdutosGeral.ProdutoFilialEstoque == null || objProdutosGeral.ProdutoFilialEstoque.Count == 0)
                    {
                        rbnEstoque.Enabled = false;
                    }
                }
                else
                {
                    rbnEmpresa.Enabled = false;
                    rbnFilial.Enabled = false;
                    rbnEstoque.Enabled = false;
                }
            }
        }

        private void DesmarcarGrids(ref DataGridView objGrid, Boolean ExecutarCheckBox)
        {

            if (objGrid.Rows != null && objGrid.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in objGrid.Rows)
                {
                    if (ExecutarCheckBox) row.Cells[0].Value = false;
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.LightGray;
                }

                objGrid.ClearSelection();
            }

        }

        private void HabilitarGrids(ref DataGridView objGrid)
        {

            if (objGrid.Rows != null && objGrid.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in objGrid.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                }

                objGrid.ClearSelection();
            }

        }

        private void DesenharCelula(object sender, DataGridViewCellPaintingEventArgs e, ButtonState Estado)
        {
            e.PaintBackground(e.CellBounds, true);

            Rectangle r = e.CellBounds;

            r.Width = 13;

            r.Height = 13;

            r.X += e.CellBounds.Width / 2 - 7;

            r.Y += e.CellBounds.Height / 2 - 7;

            ControlPaint.DrawCheckBox(e.Graphics, r, Estado);

            e.Handled = true;
        }

        private void ExecutarGravar()
        {

            if (!chkPorHorario.Checked)
            {
                if (_objProdutoPromocao == null && Convert.ToDateTime(dtpInicio.Value.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Data início não pode ser menor que a data atual.");
                }
                else if (_objProdutoPromocao != null && !_objProdutoPromocao.DataInicio.ToShortDateString().Equals(dtpInicio.Value.ToShortDateString()) &&
                         Convert.ToDateTime(dtpInicio.Value.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Data início não pode ser menor que a data atual.");
                }

                if (Convert.ToDateTime(dtpFim.Value.ToShortDateString()) < Convert.ToDateTime(dtpInicio.Value.ToShortDateString()))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Data fim não pode ser menor que a data início.");
                }
            }
            else
            {
                if (chklistadiassemana.SelectedItems != null && chklistadiassemana.SelectedItems.Count > 0)
                {
                    if (TimeSpan.Compare(dtpInicio.Value.TimeOfDay, dtpFim.Value.TimeOfDay) == 1)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Hora início não pode ser menor que a hora final.");
                    }
                }
            }
            if (string.IsNullOrEmpty(txtValorDesconto.Text) && string.IsNullOrEmpty(txtPercentual.Text))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório informar percentual do desconto ou valor do desconto.");
            }

            Comum.Clases.ProdutoPromocao objProdutoPromocao = new Comum.Clases.ProdutoPromocao();

            objProdutoPromocao.Descricao = txtNome.Text.Trim();
            objProdutoPromocao.Identificador = _IdentificadorProdutoPromocao;

            if (rbnEmpresa.Checked)
            {
                objProdutoPromocao.CodigoTipoPromocao = Comum.Clases.Constantes.COD_TIPO_PROMOCAO_EMPRESA;

                if (dgvProdutoEmpresa != null && dgvProdutoEmpresa.Rows.Count > 0)
                {

                    objProdutoPromocao.PrudutosEmpresa = new List<Comum.Clases.ProdutoServico>();

                    foreach (DataGridViewRow dr in dgvProdutoEmpresa.Rows)
                    {

                        if (Convert.ToBoolean(dr.Cells[colSelecionarEmpresa.Index].Value))
                        {
                            objProdutoPromocao.PrudutosEmpresa.Add(new Comum.Clases.ProdutoServico
                            {
                                Identificador = dr.Cells[colIdentificadorEmpresa.Index].Value as string
                            });
                        }
                    }

                }


            }
            else if (rbnEstoque.Checked)
            {
                objProdutoPromocao.CodigoTipoPromocao = Comum.Clases.Constantes.COD_TIPO_PROMOCAO_ESTOQUE;

                if (dgvProdutosEstoque != null && dgvProdutosEstoque.Rows.Count > 0)
                {

                    objProdutoPromocao.ProdutosCompra = new List<Comum.Clases.ProdutoServico>();

                    foreach (DataGridViewRow dr in dgvProdutosEstoque.Rows)
                    {

                        if (Convert.ToBoolean(dr.Cells[colSelecionarCompras.Index].Value))
                        {
                            objProdutoPromocao.ProdutosCompra.Add(new Comum.Clases.ProdutoServico
                            {
                                Identificador = dr.Cells[colIdentificadorProdutoServicoC.Index].Value as string,
                                IdentificadorProdutoCompra = dr.Cells[colIdentificadorCompras.Index].Value as string,
                                IdentificadorProdutoFilial = dr.Cells[colIdentificadorProdutoFilialC.Index].Value as string
                            });
                        }
                    }

                }
            }
            else
            {
                objProdutoPromocao.CodigoTipoPromocao = Comum.Clases.Constantes.COD_TIPO_PROMOCAO_FILIAL;

                if (dgvProdutosFilial != null && dgvProdutosFilial.Rows.Count > 0)
                {

                    objProdutoPromocao.ProdutosPorFilial = new List<Comum.Clases.ProdutoServico>();

                    foreach (DataGridViewRow dr in dgvProdutosFilial.Rows)
                    {

                        if (Convert.ToBoolean(dr.Cells[colSelecionarFilial.Index].Value))
                        {
                            objProdutoPromocao.ProdutosPorFilial.Add(new Comum.Clases.ProdutoServico
                            {
                                Identificador = dr.Cells[colIdentificadorProdutoServicoF.Index].Value as string,
                                IdentificadorProdutoFilial = dr.Cells[colIdentificadorFilial.Index].Value as string
                            });
                        }
                    }

                }

            }

            objProdutoPromocao.DataFim = dtpFim.Value;
            objProdutoPromocao.DataInicio = dtpInicio.Value;
            objProdutoPromocao.Habilitada = chkHabilitada.Checked;

            if (!string.IsNullOrEmpty(txtPercentual.Text))
            {
                objProdutoPromocao.PercentualDesconto = Convert.ToDecimal(txtPercentual.Text);
            }


            if (!string.IsNullOrEmpty(txtValorDesconto.Text))
            {
                objProdutoPromocao.Valor = Convert.ToDecimal(txtValorDesconto.Text);
            }

            objProdutoPromocao.PorHorario = chkPorHorario.Checked;

            if (objProdutoPromocao.PorHorario)
            {
                objProdutoPromocao.DiasSemana = new List<Comum.Enumeradores.Enumeradores.DiasSemana>();
                foreach (int i in chklistadiassemana.CheckedIndices)
                {
                    if (i == 0)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Domingo);
                    }
                    else if (i == 1)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Segunda);
                    }
                    else if (i == 2)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Terça);
                    }
                    else if (i == 3)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Quarta);
                    }
                    else if (i == 4)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Quinta);
                    }
                    else if (i == 5)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Sexta);
                    }
                    else if (i == 6)
                    {
                        objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Sábado);
                    }
                }
            }

            ContratoServico.ProdutoPromocao.SetProdutoPromocao.PeticaoSetProdutoPromocao Peticao = new ContratoServico.ProdutoPromocao.SetProdutoPromocao.PeticaoSetProdutoPromocao();

            Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.ProdutoPromocao = objProdutoPromocao;

            Agente.Agente.InvocarServico<ContratoServico.ProdutoPromocao.SetProdutoPromocao.RespostaSetProdutoPromocao, ContratoServico.ProdutoPromocao.SetProdutoPromocao.PeticaoSetProdutoPromocao>(Peticao, SDK.Operacoes.operacao.SetProdutoPromocao,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);

        }

        #endregion

        #region"Eventos"


        private void rbnEmpresa_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (rbnEmpresa.Checked)
                {
                    DesmarcarGrids(ref dgvProdutosEstoque, true);
                    DesmarcarGrids(ref dgvProdutosFilial, true);

                    dgvProdutosFilial.Enabled = false;
                    dgvProdutosEstoque.Enabled = false;
                    dgvProdutoEmpresa.Enabled = true;

                    HabilitarGrids(ref dgvProdutoEmpresa);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbnFilial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnFilial.Checked)
                {
                    DesmarcarGrids(ref dgvProdutosEstoque, true);
                    DesmarcarGrids(ref dgvProdutoEmpresa, true);

                    dgvProdutosFilial.Enabled = true;
                    dgvProdutosEstoque.Enabled = false;
                    dgvProdutoEmpresa.Enabled = false;

                    HabilitarGrids(ref dgvProdutosFilial);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbnEstoque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnEstoque.Checked)
                {
                    DesmarcarGrids(ref dgvProdutosFilial, true);
                    DesmarcarGrids(ref dgvProdutoEmpresa, true);

                    dgvProdutosFilial.Enabled = false;
                    dgvProdutosEstoque.Enabled = true;
                    dgvProdutoEmpresa.Enabled = false;

                    HabilitarGrids(ref dgvProdutosEstoque);
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutoEmpresa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            try
            {
                if (!rbnEmpresa.Checked && e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DesenharCelula(sender, e, ButtonState.Inactive);
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutosFilial_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (!rbnFilial.Checked && e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DesenharCelula(sender, e, ButtonState.Inactive);
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutosEstoque_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (!rbnEstoque.Checked && e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DesenharCelula(sender, e, ButtonState.Inactive);
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutoEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colSelecionarEmpresa.Index)
                {

                    if (dgvProdutoEmpresa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgvProdutoEmpresa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                    else
                    {
                        dgvProdutoEmpresa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(Boolean)(dgvProdutoEmpresa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    }


                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutosFilial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colSelecionarFilial.Index)
                {

                    if (dgvProdutosFilial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgvProdutosFilial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                    else
                    {
                        dgvProdutosFilial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(Boolean)(dgvProdutosFilial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    }


                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutosEstoque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colSelecionarCompras.Index)
                {

                    if (dgvProdutosEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgvProdutosEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                    else
                    {
                        dgvProdutosEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(Boolean)(dgvProdutosEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    }


                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorDesconto);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPercentual_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentual);

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
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void chkPorHorario_CheckedChanged(object sender, EventArgs e)
        {
            chklistadiassemana.Visible = chkPorHorario.Checked;
            if (!chklistadiassemana.Visible)
            {
                foreach (int i in chklistadiassemana.CheckedIndices)
                {
                    chklistadiassemana.SetItemCheckState(i, CheckState.Unchecked);
                }

                dtpInicio.Format = DateTimePickerFormat.Long;
                dtpFim.Format = DateTimePickerFormat.Long;
                dtpInicio.ShowUpDown = false;
                dtpFim.ShowUpDown = false;
            }

            else
            {

                dtpInicio.Format = DateTimePickerFormat.Custom;
                dtpInicio.CustomFormat = "HH:mm:ss";
                dtpInicio.ShowUpDown = true;
                dtpFim.Format = DateTimePickerFormat.Custom;
                dtpFim.CustomFormat = "HH:mm:ss";
                dtpFim.ShowUpDown = true;
            }



        }

        #endregion

    }
}
