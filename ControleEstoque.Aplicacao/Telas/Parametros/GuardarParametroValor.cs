using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;


namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarParametroValor : TelaBase.BaseCE
    {
        #region"Variaveis"
        private List<Comum.Clases.GrupoParametro> objGruposParametros;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Gravar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpGeral);
            RecuperarGrupoParametros();
            base.Inicializar();
        }

        public GuardarParametroValor()
        {
            InitializeComponent();

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

        private void RecuperarGrupoParametros()
        {

            ContratoServico.Parametro.RecuperarGrupoParametros.PeticaoRecuperarGrupoParametros Peticao = new ContratoServico.Parametro.RecuperarGrupoParametros.PeticaoRecuperarGrupoParametros();
            Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Parametro.RecuperarGrupoParametros.RespostaRecuperarGrupoParametros, ContratoServico.Parametro.RecuperarGrupoParametros.PeticaoRecuperarGrupoParametros>(Peticao,
                SDK.Operacoes.operacao.RecuperarGrupoParametros, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarGrupoParametros)
            {
                objGruposParametros = ((ContratoServico.Parametro.RecuperarGrupoParametros.RespostaRecuperarGrupoParametros)objSaida).GrupoParametros;
                CarregarParametros();
            }
            else if (operacao == SDK.Operacoes.operacao.SetParametros)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            }

        }

        private void CarregarParametros()
        {
            if (objGruposParametros != null && objGruposParametros.Count > 0)
            {
                foreach (var gp in objGruposParametros)
                {

                    if (gp.Parametros != null && gp.Parametros.Count > 0)
                    {

                        TabPage tp = new TabPage(gp.Descricao);
                        tbcGrupoParametros.TabPages.Add(tp);
                        TableLayoutPanel tlp = new TableLayoutPanel();
                        tlp.Dock = DockStyle.Fill;
                        tlp.Margin = new Padding(10, 20, 10, 10);
                        tlp.AutoScroll = true;
                        tp.Controls.Add(tlp);

                        int y = 0;

                        foreach (var p in gp.Parametros.OrderByDescending(x=> x.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.CHECKBOX))
                        {
                            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

                            tlp.Controls.Add(new Label()
                            {
                                Text = p.Descricao,
                                Name = "lbl;" + p.Codigo,
                                AutoSize = true,
                                Anchor = (AnchorStyles.Left | AnchorStyles.Top)
                            }, 0, y);

                            if (p.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.TEXTBOX)
                            {
                                TextBox txt = new TextBox() { Tag = "txt;" + p.Codigo, Dock = DockStyle.Fill };
                                txt.Text = p.DesValor;
                                txt.Anchor = (AnchorStyles.Left | AnchorStyles.Top);

                                tlp.Controls.Add(txt, 1, y);
                            }
                            else if (p.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.NUMERICO)
                            {
                                TextBox txt = new TextBox() { Tag = "txt;" + p.Codigo, Dock = DockStyle.Fill, MaxLength = 8 };

                                txt.KeyPress += new KeyPressEventHandler(txtNumerico_KeyPress);
                                txt.Text = p.DesValor;
                                txt.Anchor = (AnchorStyles.Left | AnchorStyles.Top);

                                tlp.Controls.Add(txt, 1, y);
                            }
                            else if (p.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.CHECKBOX)
                            {
                                CheckBox chk = new CheckBox() { Tag = "chk;" + p.Codigo, Dock = DockStyle.Fill };
                                chk.Checked = Convert.ToBoolean(p.DesValor == "1" ? true : false);
                                chk.Anchor = (AnchorStyles.Left | AnchorStyles.Top);

                                tlp.Controls.Add(chk, 1, y);
                            }
                            else if (p.TipoComponente == Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX)
                            {
                                ComboBox cmb = new ComboBox() { Tag = "cmb;" + p.Codigo, Dock = DockStyle.Fill };
                                cmb.Anchor = (AnchorStyles.Left | AnchorStyles.Top);

                                if (p.ValoresPossiveis != null && p.ValoresPossiveis.Count > 0)
                                {
                                    List<frmWindows.Item> Items = new List<frmWindows.Item>();
                                    foreach (var vp in p.ValoresPossiveis)
                                    {
                                        frmWindows.Item item = new frmWindows.Item();
                                        item.Identificador = vp.Codigo;
                                        item.Descricao = vp.DesValorPossivel;
                                        Items.Add(item);
                                    }
                                    cmb = frmWindows.Util.PreencherCombobox(cmb, Items);

                                    if (!string.IsNullOrEmpty(p.DesValor))
                                    {
                                        cmb = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmb, p.DesValor, "Identificador"));
                                    }
                                }

                                tlp.Controls.Add(cmb, 1, y);
                            }
                            y++;
                        }                        
                    }
                }
            }
        }

        private void txtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.'))
                {
                    e.Handled = true;
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
                List<Control> listaControles = RecuperarControles();
                if (listaControles != null && listaControles.Count > 0 && objGruposParametros != null && objGruposParametros.Count > 0)
                {
                    foreach (Control controle in listaControles)
                    {

                        // recupera o codigo do parametro que foi atribuido ao carregar a tela
                        string codigoParametro = controle.Tag.ToString().Split(';')[1];

                        Comum.Clases.Parametro parametro = (from gp in objGruposParametros
                                                            from p in gp.Parametros
                                                            where p.Codigo == codigoParametro
                                                            select p).FirstOrDefault();

                        if (parametro != null)
                        {
                            if (controle.GetType() == typeof(TextBox))
                            {
                                TextBox txt = (TextBox)controle;
                                parametro.DesValor = txt.Text;
                            }
                            else if (controle.GetType() == typeof(CheckBox))
                            {
                                CheckBox chk = (CheckBox)controle;
                                parametro.DesValor = chk.Checked ? "1" : "0";
                            }
                            else if (controle.GetType() == typeof(ComboBox))
                            {
                                ComboBox cmb = (ComboBox)controle;
                                string valor = null;
                                if (cmb.SelectedItem != null)
                                {
                                    frmWindows.Item item = (frmWindows.Item)cmb.SelectedItem;
                                    valor = item.Identificador;
                                }
                                parametro.DesValor = valor;
                            }
                        }
                    }
                    // chamada para gravar valores dos parametros na base de dados
                    Gravar();
                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro
                {
                    Execao = ex,
                    DesErro = ex.Message,
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
                });
            }
        }

        private void Gravar()
        {
            ContratoServico.Parametro.SetParametros.PeticaoSetParametros Peticao = new ContratoServico.Parametro.SetParametros.PeticaoSetParametros();
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.Parametros = (from gp in objGruposParametros
                                  from p in gp.Parametros
                                  select p).ToList();

            Agente.Agente.InvocarServico<ContratoServico.Parametro.SetParametros.RespostaSetParametros, ContratoServico.Parametro.SetParametros.PeticaoSetParametros>(Peticao,
                SDK.Operacoes.operacao.SetParametros, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
        }

        private List<Control> RecuperarControles()
        {
            List<Control> listaControles = new List<Control>();

            foreach (Control controles in this.Controls)
            {
                if (controles.GetType() == typeof(TableLayoutPanel))
                {
                    TableLayoutPanel tblp = (TableLayoutPanel)controles;
                    foreach (Control tablelayoutpanel in tblp.Controls)
                    {
                        if (tablelayoutpanel.GetType() == typeof(Panel))
                        {
                            Panel pnl = (Panel)tablelayoutpanel;

                            foreach (Control panel in pnl.Controls)
                            {
                                if (panel.GetType() == typeof(TableLayoutPanel))
                                {
                                    TableLayoutPanel tblp2 = (TableLayoutPanel)panel;

                                    foreach (Control tablelayoutpanel2 in tblp2.Controls)
                                    {
                                        if (tablelayoutpanel2.GetType() == typeof(TabControl))
                                        {
                                            TabControl tbc = (TabControl)tablelayoutpanel2;

                                            foreach (Control tabcontrol in tbc.Controls)
                                            {
                                                if (tabcontrol.GetType() == typeof(TabPage))
                                                {
                                                    TabPage tbp = (TabPage)tabcontrol;
                                                    foreach (Control tabpage in tbp.Controls)
                                                    {
                                                        if (tabpage.GetType() == typeof(TableLayoutPanel))
                                                        {
                                                            TableLayoutPanel tblp3 = (TableLayoutPanel)tabpage;
                                                            foreach (Control controleValor in tblp3.Controls)
                                                            {
                                                                if (controleValor.GetType() != typeof(Label))
                                                                {
                                                                    listaControles.Add(controleValor);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return listaControles;
        }
    }

}
