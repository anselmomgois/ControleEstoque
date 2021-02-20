using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using System.IO;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoServico : TelaBase.BaseCE
    {
        public GuardarProdutoServico(string IdentificadorProdutoServico, Boolean Visualizar)
        {
            InitializeComponent();

            _IdentificadorProdutoServico = IdentificadorProdutoServico;
            _Visualizar = Visualizar;
            this.pnlBase.Controls.Add(gpbProdutoServiço);
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorProdutoServico;
        private Comum.Clases.ProdutoServico _objProdutoServico;
        private List<Comum.Clases.Cor> _cores;
        private List<Comum.Clases.Acrescimo> _Acrescimos;
        private List<Comum.Clases.ProdutoObservacao> _ProdutoObservacoes;
        private List<Comum.Clases.UnidadeMedida> _unidadesMedida;
        private List<Comum.Clases.ProdutoMarca> _marcas;
        private List<Comum.Clases.ProdutoCategoria> _categorias;
        private List<Comum.Clases.ProdutoDerivacao> _derivacoes;
        private List<Comum.Clases.GrupoProduto> _grupos;
        private List<Comum.Clases.ProdutoNCM> _CodigosNCM;
        private List<Comum.Clases.ProdutoCST> _ProdutosCST;
        private List<Comum.Clases.ProdutoCFOP> _ProdutosCFOP;
        private Comum.Clases.TipoProdutoServico _tipoProduto;
        private Comum.Clases.TipoProdutoServico _tipoServico;
        private ExibirFoto frmFoto;
        private CurrencyTextBox CurrencyTextBox;
        private string CaminhoImagem;
        private Boolean _Visualizar;
        private List<Comum.Clases.ProdutoServicoCodigoBarras> _objCodigosBarras;

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
            this.pnlBase.Controls.Add(gpbProdutoServiço);
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

        }

        private void CarregarDados()
        {

            ContratoServico.Telas.GuardarProdutoServico.Carregar.PeticaoGuardarProdutoServicoCarregar Peticao = new ContratoServico.Telas.GuardarProdutoServico.Carregar.PeticaoGuardarProdutoServicoCarregar()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorProdutoServico = _IdentificadorProdutoServico,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarProdutoServico.Carregar.RespostaGuardarProdutoServicoCarregar, ContratoServico.Telas.GuardarProdutoServico.Carregar.PeticaoGuardarProdutoServicoCarregar>(Peticao,
                  SDK.Operacoes.operacao.CarregarGuardarProdutoServico, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarProdutoServico)
            {
                ContratoServico.Telas.GuardarProdutoServico.Carregar.RespostaGuardarProdutoServicoCarregar objRespostaConvertido = (ContratoServico.Telas.GuardarProdutoServico.Carregar.RespostaGuardarProdutoServicoCarregar)objSaida;

                _categorias = objRespostaConvertido.Categorias;
                _cores = objRespostaConvertido.Cores;
                _derivacoes = objRespostaConvertido.Derivacoes;
                _grupos = objRespostaConvertido.GruposProduto;
                _marcas = objRespostaConvertido.Marcas;
                _ProdutosCFOP = objRespostaConvertido.ProdutosCFOPs;
                _ProdutosCST = objRespostaConvertido.ProdutosCSTs;
                _unidadesMedida = objRespostaConvertido.UnidadesMedida;
                _objProdutoServico = objRespostaConvertido.ProdutoServico;
                _CodigosNCM = objRespostaConvertido.ProdutosNCMs;
                _tipoProduto = objRespostaConvertido.TipoProduto;
                _tipoServico = objRespostaConvertido.TipoServico;
                _Acrescimos = objRespostaConvertido.Acrescimos;
                _ProdutoObservacoes = objRespostaConvertido.Observacoes;

                PreencherListaObservacoes();
                PreencherListaAcrescimos();
                PreencherComboCores();
                PreencherComboProdutoCFOP();
                PreencherComboProdutoCST();
                PreencherComboNCM();
                PreencherComboDerivacoes();
                PreencherComboCategorias();
                PreencherComboUnidadeMedida();
                PreencherComboMarca();
                PreencherListGrupos();
                PreencherControles();
            }
            else if (operacao == SDK.Operacoes.operacao.SetProdutoServico)
            {
                base.objNotificacao.ExibirMensagem("Dados gravados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void PreencherComboCores()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_cores, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbCor = frmWindows.Util.PreencherCombobox(cmbCor, Items);
            }
            else
            {
                cmbCor.Enabled = false;
            }

        }

        private void PreencherListaAcrescimos()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Acrescimos, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                lstAcrescimo = frmWindows.Util.PreencherListBox(lstAcrescimo, Items);
            }
            else
            {
                lstAcrescimo.Enabled = false;
            }

        }

        private void PreencherListaObservacoes()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_ProdutoObservacoes, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                lstObservacao = frmWindows.Util.PreencherListBox(lstObservacao, Items);
            }
            else
            {
                lstAcrescimo.Enabled = false;
            }

        }

        private void PreencherComboProdutoCST()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_ProdutosCST, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbCst = frmWindows.Util.PreencherCombobox(cmbCst, Items);
            }
            else
            {
                cmbCst.Enabled = false;
            }

        }

        private void PreencherComboProdutoCFOP()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_ProdutosCFOP, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbCFOP = frmWindows.Util.PreencherCombobox(cmbCFOP, Items);
            }
            else
            {
                cmbCFOP.Enabled = false;
            }

        }

        private void PreencherComboNCM()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_CodigosNCM, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbNcm = frmWindows.Util.PreencherCombobox(cmbNcm, Items);
            }
            else
            {
                cmbNcm.Enabled = false;
            }

        }

        private void PreencherComboDerivacoes()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_derivacoes, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbDerivacao = frmWindows.Util.PreencherCombobox(cmbDerivacao, Items);
            }
            else
            {
                cmbDerivacao.Enabled = false;
            }


        }

        private void PreencherComboCategorias()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_categorias, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbCategoria = frmWindows.Util.PreencherCombobox(cmbCategoria, Items);
            }
            else
            {
                cmbCategoria.Enabled = false;
            }

        }

        private void PreencherComboUnidadeMedida()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_unidadesMedida, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                lstUnidadeMedida = frmWindows.Util.PreencherListBox(lstUnidadeMedida, Items);
            }
            else
            {
                lstUnidadeMedida.Enabled = false;
            }

        }

        private void PreencherComboMarca()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_marcas, "Identificador", "Descricao");
            if (Items != null && Items.Count > 0)
            {
                cmbMarca = frmWindows.Util.PreencherCombobox(cmbMarca, Items);
            }
            else
            {
                cmbMarca.Enabled = false;
            }

        }

        private void PreencherListGrupos()
        {

            if (_grupos != null && _grupos.Count > 0)
            {

                TreeNode Nodo = null;
                Comum.Clases.GrupoProduto objGrupo = null;

                foreach (Comum.Clases.GrupoProduto gp in _grupos)
                {

                    objGrupo = LogicaNegocio.GrupoProduto.RecuperarGrupoProduto(gp.Identificador, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);

                    Nodo = new TreeNode();

                    PreencherNode(ref Nodo, objGrupo);

                    trvGrupo.Nodes.Add(Nodo);
                }
            }
        }

        private void PreencherNode(ref TreeNode Nodo, Comum.Clases.GrupoProduto Grupo)
        {

            Nodo.Name = Grupo.Identificador;
            Nodo.Text = Grupo.Descricao;

            if (Grupo.SubGrupos != null && Grupo.SubGrupos.Count > 0)
            {

                TreeNode NodoFilho = null;

                foreach (Comum.Clases.GrupoProduto gp in Grupo.SubGrupos)
                {

                    NodoFilho = new TreeNode();

                    PreencherNode(ref NodoFilho, gp);

                    Nodo.Nodes.Add(NodoFilho);
                }

            }

        }

        private void CarregarTela()
        {
            CarregarDados();
            ConfigurarVisibilidade();

        }

        private void PreencherControles()
        {

            if (_objProdutoServico != null)
            {

                txtCodigo.Text = Convert.ToString(_objProdutoServico.Codigo);
                // txtCodigoBarras.Text = _objProdutoServico.CodigoBarras;
                txtDescricao.Text = _objProdutoServico.Descricao;
                txtObservacao.Text = _objProdutoServico.Observacao;
                chkVendaNumSerie.Checked = _objProdutoServico.VendaPorNumeroSerie;
                chkAcrescimo.Checked = _objProdutoServico.Acrescimo;
                chkInterno.Checked = _objProdutoServico.ProdutoInterno;
                chkVendaAgranel.Checked = _objProdutoServico.VendaAGranel;

                if (_objProdutoServico.CodigosBarras != null && _objProdutoServico.CodigosBarras.Count > 0)
                {
                    _objCodigosBarras = _objProdutoServico.CodigosBarras;
                    PreencherCodigoBarras();
                }

                if (_objProdutoServico.TipoProdutoServico != null)
                {

                    if (_objProdutoServico.TipoProdutoServico.Codigo == Comum.Clases.Constantes.COD_TIPO_PRODUTO_SERVICO_PROD)
                    {
                        rbnProduto.Checked = true;
                    }
                    else
                    {
                        rbnServico.Checked = true;
                    }
                }

                if (_objProdutoServico.Cor != null)
                {
                    cmbCor = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbCor, _objProdutoServico.Cor.Identificador, "Identificador"));
                }

                if (_objProdutoServico.ProdutoNCM != null)
                {
                    cmbNcm = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbNcm, _objProdutoServico.ProdutoNCM.Identificador, "Identificador"));
                }

                if (_objProdutoServico.UnidadesMedida != null && _objProdutoServico.UnidadesMedida.Count > 0)
                {
                    lstUnidadeMedida = (ListBox)(frmWindows.Util.SelecionarItemControle(lstUnidadeMedida, _objProdutoServico.UnidadesMedida.First().Identificador, "Identificador"));
                }

                if (_objProdutoServico.Acrescimos != null && _objProdutoServico.Acrescimos.Count > 0)
                {
                    lstAcrescimo = (ListBox)(frmWindows.Util.SelecionarItemControle(lstAcrescimo, string.Empty, "Identificador", _objProdutoServico.Acrescimos));
                }

                if (_objProdutoServico.ObservacoesProduto != null && _objProdutoServico.ObservacoesProduto.Count > 0)
                {
                    lstObservacao = (ListBox)(frmWindows.Util.SelecionarItemControle(lstObservacao, string.Empty, "Identificador", _objProdutoServico.ObservacoesProduto));
                }

                if (_objProdutoServico.ProdutoMarca != null)
                {
                    cmbMarca = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbMarca, _objProdutoServico.ProdutoMarca.Identificador, "Identificador"));
                }

                if (_objProdutoServico.ProdutoCategoria != null)
                {
                    cmbCategoria = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbCategoria, _objProdutoServico.ProdutoCategoria.Identificador, "Identificador"));
                }

                if (_objProdutoServico.ProdutoCST != null)
                {
                    cmbCst = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbCst, _objProdutoServico.ProdutoCST.Identificador, "Identificador"));
                }

                if (_objProdutoServico.ProdutoCFOP != null)
                {
                    cmbCFOP = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbCFOP, _objProdutoServico.ProdutoCFOP.Identificador, "Identificador"));
                }

                if (_objProdutoServico.ProdutoDerivacao != null)
                {
                    cmbDerivacao = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbDerivacao, _objProdutoServico.ProdutoDerivacao.Identificador, "Identificador"));
                }

                if (_objProdutoServico.GrupoProduto != null)
                {

                    SelecionarNodo(trvGrupo.Nodes, _objProdutoServico.GrupoProduto.Identificador);

                }

                if (_objProdutoServico.ImgProduto != null)
                {
                    MemoryStream imgBits = new MemoryStream(_objProdutoServico.ImgProduto);
                    Bitmap img = new Bitmap(imgBits);
                    Image objFoto = img;
                    imgProduto.Image = objFoto;

                }
            }
        }

        private void SelecionarNodo(TreeNodeCollection Nodes, string IdentificadorGrupo)
        {

            if (Nodes != null && Nodes.Count > 0)
            {

                foreach (TreeNode Nodo in Nodes)
                {

                    if (Nodo.Name == IdentificadorGrupo)
                    {
                        trvGrupo.SelectedNode = Nodo;
                        trvGrupo.Focus();
                        return;
                    }

                    if (Nodo.Nodes != null && Nodo.Nodes.Count > 0)
                    {
                        SelecionarNodo(Nodo.Nodes, IdentificadorGrupo);
                    }
                }
            }
        }

        private void ConfigurarVisibilidade()
        {

            if (_Visualizar)
            {
                txtDescricao.Enabled = false;
                lnkAlterarFoto.Visible = false;
                txtObservacao.Enabled = false;
                txtCodigoBarras.Enabled = false;
                cmbCategoria.Enabled = false;
                cmbCor.Enabled = false;
                cmbDerivacao.Enabled = false;
                cmbMarca.Enabled = false;
                lstUnidadeMedida.Enabled = false;
                trvGrupo.Enabled = false;
                rbnProduto.Enabled = false;
                rbnServico.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
        }

        private void HabilitaDesabilitaControles()
        {

            if (rbnProduto.Checked)
            {
                cmbMarca.Enabled = true;
                lstUnidadeMedida.Enabled = true;
                cmbDerivacao.Enabled = true;
                cmbCst.Enabled = true;
                cmbCFOP.Enabled = true;
                txtCodigoBarras.Enabled = true;
            }
            else
            {

                cmbMarca.SelectedItem = null;
                cmbMarca.Enabled = false;

                lstUnidadeMedida.SelectedItems.Clear();
                lstUnidadeMedida.Enabled = false;

                cmbDerivacao.SelectedItem = null;
                cmbDerivacao.Enabled = false;

                txtCodigoBarras.Enabled = false;
                txtCodigoBarras.Text = string.Empty;

                cmbCFOP.SelectedItem = null;
                cmbCFOP.Enabled = false;

                cmbCst.SelectedItem = null;
                cmbCst.Enabled = false;

            }

        }

        private void ExecutarGravar()
        {

            if(trvGrupo.SelectedNode == null || string.IsNullOrEmpty(trvGrupo.SelectedNode.Name))
            {
                base.objNotificacao.ExibirMensagem("Obrigatório selecionar um grupo de produto.", Controles.UcNotificacao.TipoImagem.WARNING);
                return;
            }
            Comum.Clases.ProdutoServico objProdutoServico = new Comum.Clases.ProdutoServico();

            objProdutoServico.Identificador = _IdentificadorProdutoServico;

            objProdutoServico.Observacao = txtObservacao.Text;

            objProdutoServico.CodigosBarras = _objCodigosBarras;
            objProdutoServico.Descricao = txtDescricao.Text;

            Comum.Clases.TipoProdutoServico objtipo = new Comum.Clases.TipoProdutoServico();

            objtipo = (rbnProduto.Checked ? _tipoProduto : _tipoServico);

            if (objtipo != null)
            {
                objProdutoServico.TipoProdutoServico = objtipo;
            }

            if (!string.IsNullOrEmpty(CaminhoImagem))
            {

                //Cria um novo FileStream para leitura da imagem
                FileStream fs = new FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read);

                //Cria um array de Bytes do tamanho do FileStream
                byte[] picture = new byte[fs.Length - 1];

                //Lê os bytes do FileStream para o array criado
                fs.Read(picture, 0, picture.Length);

                //Fecha o FileStream ficando a imagem guardada no array
                fs.Close();

                objProdutoServico.ImgProduto = picture;
            }

            if (trvGrupo.SelectedNode != null)
            {
                objProdutoServico.GrupoProduto = new Comum.Clases.GrupoProduto() { Identificador = trvGrupo.SelectedNode.Name };

            }


            if (cmbCategoria.SelectedItem != null)
            {
                objProdutoServico.ProdutoCategoria = (Comum.Clases.ProdutoCategoria)(frmWindows.Util.RecuperarItemSelecionado(cmbCategoria, _categorias, "Identificador"));
            }

            if (cmbNcm.SelectedItem != null)
            {
                objProdutoServico.ProdutoNCM = (Comum.Clases.ProdutoNCM)(frmWindows.Util.RecuperarItemSelecionado(cmbNcm, _CodigosNCM, "Identificador"));
            }

            if (cmbCor.SelectedItem != null)
            {
                objProdutoServico.Cor = (Comum.Clases.Cor)(frmWindows.Util.RecuperarItemSelecionado(cmbCor, _cores, "Identificador"));
            }

            if (cmbDerivacao.SelectedItem != null)
            {
                objProdutoServico.ProdutoDerivacao = (Comum.Clases.ProdutoDerivacao)(frmWindows.Util.RecuperarItemSelecionado(cmbDerivacao, _derivacoes, "Identificador"));
            }

            if (cmbCFOP.SelectedItem != null)
            {
                objProdutoServico.ProdutoCFOP = (Comum.Clases.ProdutoCFOP)(frmWindows.Util.RecuperarItemSelecionado(cmbCFOP, _ProdutosCFOP, "Identificador"));
            }

            if (cmbCst.SelectedItem != null)
            {
                objProdutoServico.ProdutoCST = (Comum.Clases.ProdutoCST)(frmWindows.Util.RecuperarItemSelecionado(cmbCst, _ProdutosCST, "Identificador"));
            }

            if (cmbMarca.SelectedItem != null)
            {
                objProdutoServico.ProdutoMarca = (Comum.Clases.ProdutoMarca)(frmWindows.Util.RecuperarItemSelecionado(cmbMarca, _marcas, "Identificador"));
            }

            if (lstUnidadeMedida.SelectedItem != null)
            {
                objProdutoServico.UnidadesMedida = (List<Comum.Clases.UnidadeMedida>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.UnidadeMedida>(lstUnidadeMedida, _unidadesMedida, "Identificador"));
            }
            else if (rbnProduto.Checked)
            {
                base.objNotificacao.ExibirMensagem("A unidade de medida é obrigatória", Controles.UcNotificacao.TipoImagem.WARNING);
                return;
            }

            if (lstAcrescimo.SelectedItems != null)
            {
                objProdutoServico.Acrescimos = (List<Comum.Clases.Acrescimo>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Acrescimo>(lstAcrescimo, _Acrescimos, "Identificador"));
            }

            if (lstObservacao.SelectedItems != null)
            {
                objProdutoServico.ObservacoesProduto = (List<Comum.Clases.ProdutoObservacao>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.ProdutoObservacao>(lstObservacao, _ProdutoObservacoes, "Identificador"));
            }

            objProdutoServico.Acrescimo = chkAcrescimo.Checked;
            objProdutoServico.ProdutoInterno = chkInterno.Checked;
            objProdutoServico.VendaAGranel = chkVendaAgranel.Checked;
            objProdutoServico.VendaPorNumeroSerie = chkVendaNumSerie.Checked;

            ContratoServico.ProdutoServico.SetProdutoServico.PeticaoSetProdutoServico Peticao = new ContratoServico.ProdutoServico.SetProdutoServico.PeticaoSetProdutoServico()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                ProdutoServico = objProdutoServico,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.ProdutoServico.SetProdutoServico.RespostaInserirProdutoServico, ContratoServico.ProdutoServico.SetProdutoServico.PeticaoSetProdutoServico>(Peticao,
                  SDK.Operacoes.operacao.SetProdutoServico, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);


        }

        private void PreencherLabelGrupoSelecionado(TreeNode nodo)
        {
            if (nodo.Parent != null)
            {
                PreencherLabelGrupoSelecionado(nodo.Parent);
            }

            lblGrupoSelecionado.Text += " > " + nodo.Text;
        }

        private void AdicionarCodigoBarras()
        {
            if (!string.IsNullOrEmpty(txtCodigoBarras.Text) && (_objCodigosBarras == null ||
                (_objCodigosBarras != null && _objCodigosBarras.Count > 0 && !_objCodigosBarras.Exists(cb => cb.CodigoBarras == txtCodigoBarras.Text))))
            {

                if (!frmUtil.Validacao.ValidarValorCampo(txtCodigoBarras.Text, frmUtil.Enumeradores.TipoValidacao.EAN13))
                {
                    txtCodigoBarras.SelectAll();
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, ("Código de barras inválido"));
                }

                if (_objCodigosBarras == null) { _objCodigosBarras = new List<Comum.Clases.ProdutoServicoCodigoBarras>(); }

                _objCodigosBarras.Add(new Comum.Clases.ProdutoServicoCodigoBarras()
                {
                    CodigoBarras = txtCodigoBarras.Text
                });

                PreencherCodigoBarras();
            }
            txtCodigoBarras.Text = string.Empty;
            txtCodigoBarras.Focus();
        }

        private void ExcluirCodigoBarras()
        {
            List<Comum.Clases.ProdutoServicoCodigoBarras> objCodigoBarras = (List<Comum.Clases.ProdutoServicoCodigoBarras>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.ProdutoServicoCodigoBarras>(lstCodigoBarras, _objCodigosBarras, "CodigoBarras"));

            if (objCodigoBarras != null && objCodigoBarras.Count > 0)
            {
                foreach (Comum.Clases.ProdutoServicoCodigoBarras cb in objCodigoBarras)
                {
                    _objCodigosBarras.RemoveAll(c => c.CodigoBarras == cb.CodigoBarras);
                }

                PreencherCodigoBarras();
            }
        }

        private void PreencherCodigoBarras()
        {
            lstCodigoBarras.Items.Clear();

            if (_objCodigosBarras != null && _objCodigosBarras.Count > 0)
            {
                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objCodigosBarras, "CodigoBarras", "CodigoBarras");
                if (Items != null && Items.Count > 0)
                {
                    lstCodigoBarras = frmWindows.Util.PreencherListBox(lstCodigoBarras, Items);
                }
                else
                {
                    lstUnidadeMedida.Enabled = false;
                }
            }
        }
        #endregion

        #region "Eventos"

        private void imgProduto_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Hand;
                lnkAlterarFoto.Visible = true;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void lnkAlterarFoto_Click(object sender, EventArgs e)
        {
            try
            {

                if (fdgImgProduto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    CaminhoImagem = fdgImgProduto.FileName;
                    imgProduto.Load(fdgImgProduto.FileName);
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void imgProduto_Click(object sender, EventArgs e)
        {
            try
            {
                frmFoto = new ExibirFoto(imgProduto.Image);
                frmFoto.ShowDialog();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbnProduto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HabilitaDesabilitaControles();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbnServico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HabilitaDesabilitaControles();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void trvGrupo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                lblGrupoSelecionado.Text = string.Empty;
                PreencherLabelGrupoSelecionado(e.Node);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AdicionarCodigoBarras();
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

        private void btnAdicionarCodigoBarras_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarCodigoBarras();
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

        private void btnExcluirCodigoBarras_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirCodigoBarras();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }


        #endregion

    }
}
