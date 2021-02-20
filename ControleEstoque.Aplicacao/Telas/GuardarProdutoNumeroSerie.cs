using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoNumeroSerie : TelaBase.BaseCE
    {
        public GuardarProdutoNumeroSerie(Comum.Clases.ProdutoCompra Produto, List<Comum.Clases.UnidadeMedida> UnidadesMedida)
        {
            InitializeComponent();
            _Produto = Produto;
            _UnidadesMedida = UnidadesMedida;

        }

        #region"Variaveis"
        Comum.Clases.ProdutoCompra _Produto;
        List<Comum.Clases.ProdutoNumeroSerie> _NumerosSerie;
        private Boolean _InicializandoTela = true;
        private decimal _QuantidadeComprada;
        private List<Comum.Clases.UnidadeMedida> _UnidadesMedida;
        #endregion

        #region"Propriedades"
        public List<Comum.Clases.ProdutoNumeroSerie> NumerosSerieRetorno { get; set; }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.aceitar, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            _QuantidadeComprada = Classes.Util.RecuperarQuantidadeComprada(_Produto, _UnidadesMedida);

            lblQuantidaCompradaValor.Text = _QuantidadeComprada.ToString();

            txtNumeroSerie.Focus();
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
        }

        private void AdicionarNumeroSerie()
        {
            if (_NumerosSerie == null) { _NumerosSerie = new List<Comum.Clases.ProdutoNumeroSerie>(); }

            if (!string.IsNullOrEmpty(txtNumeroSerie.Text) && !_NumerosSerie.Exists(ns => ns.NumeroSerie == txtNumeroSerie.Text))
            {
                _NumerosSerie.Add(new Comum.Clases.ProdutoNumeroSerie()
                {
                    NumeroSerie = txtNumeroSerie.Text,
                    Identificador = Guid.NewGuid().ToString()
                });

                PreencherGrid();
                txtNumeroSerie.Text = string.Empty;
                txtNumeroSerie.Focus();
            }
        }

        private void PreencherGrid()
        {
            dgvMarcas.Rows.Clear();

            if (_NumerosSerie != null && _NumerosSerie.Count > 0)
            {
                foreach (Comum.Clases.ProdutoNumeroSerie ns in _NumerosSerie)
                {
                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colNumeroSerie.Index].Value = ns.NumeroSerie;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = ns.Identificador;
                }

                lblQuantidadeLidaValor.Text = _NumerosSerie.Count.ToString();
                if(_QuantidadeComprada == _NumerosSerie.Count)
                {
                    txtNumeroSerie.Enabled = false;
                    btnNumeroSerie.Enabled = false;
                }
            }
        }
        #endregion

        #region  "Eventos"

        private void btnNumeroSerie_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarNumeroSerie();
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

        private void txtNumeroSerie_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AdicionarNumeroSerie();
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

        private void btnGravar_Enter(object sender, EventArgs e)
        {
            try
            {
                if (_InicializandoTela)
                {
                    _InicializandoTela = false;
                    txtNumeroSerie.Focus();
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_NumerosSerie == null || (_NumerosSerie != null && _QuantidadeComprada != _NumerosSerie.Count))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi informado todos os números de seríe comprados.");
                }

                NumerosSerieRetorno = _NumerosSerie;

                this.DialogResult = DialogResult.OK;

                this.Close();
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;

                this.Close();
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

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colExcluir.Index)
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

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0 && _NumerosSerie != null && _NumerosSerie.Count > 0)
                {
                    if (e.ColumnIndex == colExcluir.Index)
                    {

                        _NumerosSerie.RemoveAll(p => p.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                        PreencherGrid();

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