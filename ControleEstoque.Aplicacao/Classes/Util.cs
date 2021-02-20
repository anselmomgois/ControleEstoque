using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using frmEmail = AmgSistemas.Framework.Email;

namespace Informatiz.ControleEstoque.Aplicacao.Classes
{
    public class Util
    {

        public static System.Drawing.Printing.PrinterSettings PrintSettings;

        #region "Metodos"        

        public static Boolean IsNumeric(string valor)
        {
            int n;

            var isNumeric = int.TryParse(valor, out n);

            return isNumeric;
        }

        public static Boolean IsDecimal(string valor)
        {
            decimal n;

            var isNumeric = decimal.TryParse(valor, out n);

            return isNumeric;
        }

        public static decimal RecuperarQuantidadeComprada(Comum.Clases.ProdutoCompra Produto, List<Comum.Clases.UnidadeMedida> UnidadesMedida)
        {
            decimal QuantidadeComprada = Produto.NumeroQuantidadeCompra;

            Comum.Clases.UnidadeMedida UnidadeCompra = UnidadesMedida.Find(um => um.Identificador == Produto.UnidadeMedidaCompra.Identificador);

            QuantidadeComprada = CalcularQuantidade(UnidadeCompra, QuantidadeComprada);

            return QuantidadeComprada;
        }

        private static decimal CalcularQuantidade(Comum.Clases.UnidadeMedida UnidadeMedida, decimal Quantidade)
        {
            decimal QuantidadeComprada = Quantidade;


            if (UnidadeMedida.UnidademedidaPai != null)
            {
                QuantidadeComprada = Convert.ToDecimal(QuantidadeComprada * UnidadeMedida.NumValorUnidadePai);

                QuantidadeComprada = CalcularQuantidade(UnidadeMedida.UnidademedidaPai, QuantidadeComprada);
            }

            return QuantidadeComprada;
        }

        public static void DesabilitarControlesTela(Control objcontrole, Boolean Habilitado, List<string> NomeControles, ref List<string> ControlesDesabilitados)
        {

            //if (NomeControles != null && NomeControles.Count > 0)
            //{
            //    string NomeControle = objcontrole.Name;

            //    if (NomeControles.Exists(c => c == NomeControle))
            //    {
            //        objcontrole.Enabled = Habilitado;
            //    }
            //}
            //else
            //{
            //    objcontrole.Enabled = Habilitado;
            //}

            if (objcontrole.Controls != null && objcontrole.Controls.Count > 0)
            {
                foreach (Control c in objcontrole.Controls)
                {
                    Control objC = c;

                    if (!(objC is Label))
                    {
                        DesabilitarControles(ref objC, Habilitado, NomeControles, ref ControlesDesabilitados);
                    }
                }
            }
        }

        private static void DesabilitarControles(ref Control objcontrole, Boolean Habilitado, List<string> NomeControles, ref List<string> ControlesDesabilitados)
        {

            if ((objcontrole is MaskedTextBox) || (objcontrole is ComboBox) || (objcontrole is TextBox) || (objcontrole is RichTextBox) || (objcontrole is NumericUpDown) ||
                (objcontrole is TreeView) || (objcontrole is Button) || (objcontrole is DataGridView))
            {
                if (NomeControles != null && NomeControles.Count > 0)
                {
                    string NomeControle = objcontrole.Name;

                    if (NomeControles.Exists(c => c == NomeControle))
                    {
                        objcontrole.Enabled = Habilitado;
                    }
                }
                else
                {
                    if (!Habilitado && !objcontrole.Enabled)
                    {
                        if (ControlesDesabilitados == null) { ControlesDesabilitados = new List<string>(); }
                        if (!string.IsNullOrEmpty(objcontrole.Name))
                        {
                            ControlesDesabilitados.Add(objcontrole.Name);
                        }
                    }
                    else
                    {
                        if (Habilitado)
                        {
                            string NomeControle = objcontrole.Name;
                            if (ControlesDesabilitados == null || !ControlesDesabilitados.Exists(c => c == NomeControle))
                            {
                                objcontrole.Enabled = Habilitado;
                            }
                        }
                        else
                        {
                            objcontrole.Enabled = Habilitado;
                        }
                    }
                }
            }
            if (objcontrole.Controls != null && objcontrole.Controls.Count > 0)
            {
                foreach (Control c in objcontrole.Controls)
                {
                    Control objC = c;

                    DesabilitarControles(ref objC, Habilitado, NomeControles, ref ControlesDesabilitados);
                }
            }
        }

        public static Color ConverterStringEmCor(string Cor)
        {

            if (!string.IsNullOrEmpty(Cor))
            {
                string[] objStrCor = Cor.Split(Convert.ToChar("|"));

                Int32 A = Convert.ToInt32(objStrCor[0]);
                Int32 R = Convert.ToInt32(objStrCor[1]);
                Int32 G = Convert.ToInt32(objStrCor[2]);
                Int32 B = Convert.ToInt32(objStrCor[3]);

                return Color.FromArgb(A, R, G, B);
            }

            return new Color();
        }

        public static Boolean TratarRetornoServico(ContratoServico.RespostaGenerica Resposta)
        {

            if (Resposta.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
            {
                MessageBox.Show(Resposta.DescricaoErro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static Boolean ValidarPermissao(List<Comum.Clases.Permissao> objPermissoes, string CodigoPermissao, Nullable<Comum.Enumeradores.Enumeradores.TipoAcao> TipoAcao)
        {

            if (objPermissoes != null && objPermissoes.Count > 0)
            {

                Comum.Clases.Permissao objPermissao = (from Comum.Clases.Permissao objP in objPermissoes where objP.Codigo == CodigoPermissao select objP).FirstOrDefault();

                if (TipoAcao != null && objPermissao != null && objPermissao.Acoes != null && objPermissao.Acoes.Count > 0 &&
                  (from Comum.Clases.Acao objA in objPermissao.Acoes where objA.TipoAcao == TipoAcao select objA).Count() > 0)
                {

                    return true;
                }
                else if (objPermissao != null && TipoAcao == null)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ExibirMensagemErro(string Mensagem)
        {
            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(Mensagem, Controles.UcNotificacao.TipoImagem.ERRO);
        }

        public static void ExibirMensagemSucesso(string Mensagem)
        {
            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(Mensagem, Controles.UcNotificacao.TipoImagem.SUCESSO);
        }

        public static void ExibirMensagemInformacao(string Mensagem)
        {
            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(Mensagem, Controles.UcNotificacao.TipoImagem.INFORMACAO);
        }

        public static void ExibirMensagemUpdate(string Mensagem)
        {
            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(Mensagem, Controles.UcNotificacao.TipoImagem.UPDATE);
        }

        public static void ExibirMensagemDownload(string Mensagem)
        {
            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(Mensagem, Controles.UcNotificacao.TipoImagem.DOWNLOAD);
        }

        public static void ExibirMensagemWarning(string Mensagem)
        {
            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(Mensagem, Controles.UcNotificacao.TipoImagem.WARNING);
        }

        public static void ExibirMensagemMsgBox(string Mensagem, MessageBoxIcon Icon)
        {
            MessageBox.Show(Mensagem,"I - GERENCE",MessageBoxButtons.OK, Icon);
        }
               

        private static void RecuperarErro(ref string Mensagem, Exception ex)
        {

            if(ex.InnerException != null)
            {
                Mensagem += " " + ex.InnerException.Message;

                if (ex.InnerException.StackTrace != null)
                {
                    Mensagem += " " + ex.InnerException.StackTrace.ToString();
                    
                }

                RecuperarErro(ref Mensagem, ex.InnerException);
            }

        }
        public static void LogarErro(Comum.Clases.Erro objErro)
        {

            if ((objErro != null && objErro.Execao != null && objErro.Execao.GetType() != typeof(Execao.ExecaoNegocio)))
            {



                ContratoServico.Erro.InserirErro.PeticaoInserirErro Peticao = new ContratoServico.Erro.InserirErro.PeticaoInserirErro();
                Peticao.Erro = objErro;
                Peticao.Usuario = (Parametros.Parametros.InformacaoUsuario != null ? Parametros.Parametros.InformacaoUsuario.Login : string.Empty);

                SDK.AgenteApi.Agente.InvocarServico<ContratoServico.Erro.InserirErro.RespostaInserirErro, ContratoServico.Erro.InserirErro.PeticaoInserirErro>(Peticao, SDK.Operacoes.operacao.InserirErro,
                           new Comum.ParametrosTela.Generica
                           {
                               PreencherObjeto = true
                           }, null, true);
            }

            Controles.UcNotificacao objNotificacao = new Controles.UcNotificacao();
            objNotificacao.ExibirMensagem(objErro.DesErro, Controles.UcNotificacao.TipoImagem.ERRO);

        }

        public static void LogarErroMsgBox(Comum.Clases.Erro objErro)
        {

            if ((objErro != null && objErro.Execao != null && objErro.Execao.GetType() != typeof(Execao.ExecaoNegocio)))
            {



                ContratoServico.Erro.InserirErro.PeticaoInserirErro Peticao = new ContratoServico.Erro.InserirErro.PeticaoInserirErro();
                Peticao.Erro = objErro;
                Peticao.Usuario = (Parametros.Parametros.InformacaoUsuario != null ? Parametros.Parametros.InformacaoUsuario.Login : string.Empty);

                SDK.AgenteApi.Agente.InvocarServico<ContratoServico.Erro.InserirErro.RespostaInserirErro, ContratoServico.Erro.InserirErro.PeticaoInserirErro>(Peticao, SDK.Operacoes.operacao.InserirErro,
                           new Comum.ParametrosTela.Generica
                           {
                               PreencherObjeto = true
                           }, null, true);
            }

            MessageBox.Show("I - GERENCE", objErro.DesErro,MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        public static void ConfigurarFocoComponentes(Control controle)
        {


            if ((controle is DataGridView))
            {
                DataGridView grid = controle as DataGridView;

                if (grid != null)
                {
                    grid.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
                    grid.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                }


            }
            else if ((controle is MaskedTextBox) || (controle is ComboBox) || (controle is TextBox) || (controle is RichTextBox) || (controle is NumericUpDown) || (controle is TreeView))
            {
                controle.Enter += ConfigurarEnterComponente;
                controle.Leave += ConfigurarLeaveComponente;

            }

            // chamada recursiva para configurar os controles filhos do item atual 

            foreach (Control controleFilho in controle.Controls)
            {
                ConfigurarFocoComponentes(controleFilho);

            }

        }


        public static void ConfigurarEstilo(Control controle)
        {


            if (controle is Button)
            {
                Button objBotao = (Button)(controle);

                controle.BackColor = Color.FromName("GradientActiveCaption");
                controle.ForeColor = Color.Navy;
                objBotao.FlatStyle = FlatStyle.Popup;

            }
            else if (controle is TextBox)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is MaskedTextBox)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is DateTimePicker)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is ComboBox)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is DataGridView)
            {
                DataGridView objDataGrid = (DataGridView)(controle);

                controle.ForeColor = Color.Blue;
                objDataGrid.BackgroundColor = Color.FromName("GradientActiveCaption");
            }

            // chamada recursiva para configurar os controles filhos do item atual 

            foreach (Control controleFilho in controle.Controls)
            {
                ConfigurarEstilo(controleFilho);

            }

        }
        /// <summary>
        /// Configura o evento enter de um determinado componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        /// <history>
        /// [octavio.piramo] 20/01/2009 Criado
        /// </history>

        public static void ConfigurarEnterComponente(object sender, EventArgs e)
        {

            if (sender is Control)
            {
                if (ValidarComponente(sender))
                {
                    Control controle = (Control)sender;
                    controle.BackColor = System.Drawing.Color.Blue;
                    controle.ForeColor = System.Drawing.Color.White;
                }

            }

        }



        /// <summary>
        /// Confifura o evento leave de um determinado componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        /// <history>
        /// [octavio.piramo] 20/01/2009 Criado
        /// </history>

        public static void ConfigurarLeaveComponente(object sender, EventArgs e)
        {

            if (sender is Control)
            {
                if (ValidarComponente(sender))
                {
                    Control controle = (Control)sender;
                    controle.BackColor = System.Drawing.Color.White;
                    controle.ForeColor = System.Drawing.Color.Blue;
                }

            }

        }


        /// <summary>
        /// Valida se o componente está habilitado, visível e não leitura
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks></remarks>
        /// <history>
        /// [octavio.piramo] 20/01/2009 Criado
        /// </history>
        public static bool ValidarComponente(object sender)
        {

            Control controle = (Control)sender;

            // validar controle

            if (controle is MaskedTextBox)
            {
                if (!(controle as MaskedTextBox).ReadOnly)
                {
                    return true;
                }


            }
            else if (controle is TextBox)
            {
                if (!(controle as TextBox).ReadOnly)
                {
                    return true;
                }


            }
            else if (controle is RichTextBox)
            {
                if (!(controle as RichTextBox).ReadOnly)
                {
                    return true;
                }

            }

            return false;

        }

        #endregion

    }
}
