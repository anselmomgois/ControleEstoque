using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarAdministradora : TelaBase.BaseCE
    {
        public GuardarAdministradora(string IdentificadorAdministradora)
        {
            InitializeComponent();

            _IdentificadorAdministradora = IdentificadorAdministradora;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion
        
        #region"Variaveis"

        private string CaminhoImagem;
        private string _IdentificadorAdministradora;
        private Comum.Clases.Administradora _objAdministradora;
        private byte[] objImagem;
        private CurrencyTextBox CurrencyTextBox;

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
            CarregarTela();
            base.Inicializar();
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarAdministradora)
            {
                _objAdministradora = ((ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora)objSaida).Administradora;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    PreencherControles();
                }
            }
            else if(operacao == SDK.Operacoes.operacao.InserirAdministradora || operacao == SDK.Operacoes.operacao.AtualizarAdministradora)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }


        }

        private void CarregarTela()
        {

            RecuperarAdministradoras();
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            DesabilitarControles(this, Habilitado, NomeControles);

        }

        private void DesabilitarControles(Control objcontrole, Boolean Habilitado, List<string> NomeControles)
        {
            if (NomeControles != null && NomeControles.Count > 0)
            {
                if (NomeControles.Exists(c => c == objcontrole.Name))
                {
                    objcontrole.Enabled = Habilitado;
                }
            }
            else
            {
                objcontrole.Enabled = Habilitado;
            }

            if (objcontrole.Controls != null && objcontrole.Controls.Count > 0)
            {
                foreach (Control c in objcontrole.Controls)
                {
                    DesabilitarControles(c, Habilitado, NomeControles);
                }
            }
        }

        private void RecuperarAdministradoras()
        {

            if (!string.IsNullOrEmpty(_IdentificadorAdministradora))
            {

                ContratoServico.Administradora.RecuperarAdministradora.PeticaoRecuperarAdministradora Peticao = new ContratoServico.Administradora.RecuperarAdministradora.PeticaoRecuperarAdministradora();
                Peticao.IdentificadorAdministradora = _IdentificadorAdministradora;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora, ContratoServico.Administradora.RecuperarAdministradora.PeticaoRecuperarAdministradora>(Peticao,
                 SDK.Operacoes.operacao.RecuperarAdministradora, new Comum.ParametrosTela.Generica()
                 {
                     PreencherObjeto = true,
                     ExibirMensagemNenhumRegistro = false
                 },null, true);
            }

        }

        private void PreencherControles()
        {

            if (_objAdministradora != null)
            {

                txtNome.Text = _objAdministradora.Descricao;
                txtDescricaoTela.Text = _objAdministradora.DescricaoTela;
                txtObservacao.Text = _objAdministradora.Observacao;
                txtPercentualDesconto.Text = (_objAdministradora.PercentualDesconto != null ? Convert.ToString(_objAdministradora.PercentualDesconto) : string.Empty);
                txtPercentualTarifa.Text = (_objAdministradora.PercentualTarifa != null ? Convert.ToString(_objAdministradora.PercentualTarifa) : string.Empty);
                txtPercentualTarifaAnt.Text = (_objAdministradora.PercentualTarifaAntecipada != null ? Convert.ToString(_objAdministradora.PercentualTarifaAntecipada) : string.Empty);
                txtValorDesconto.Text = (_objAdministradora.ValorDesconto != null ? Convert.ToString(_objAdministradora.ValorDesconto) : string.Empty);
                txtValorTarifa.Text = (_objAdministradora.ValorTarifa != null ? Convert.ToString(_objAdministradora.ValorTarifa) : string.Empty);
                txtValorTarifaAnt.Text = (_objAdministradora.ValorTarifaAntecipada != null ? Convert.ToString(_objAdministradora.ValorTarifaAntecipada) : string.Empty);

                if (_objAdministradora != null && _objAdministradora.ImgAdministradora != null)
                {

                    MemoryStream imgBits = new MemoryStream(_objAdministradora.ImgAdministradora);
                    Bitmap img = new Bitmap(imgBits);
                    Image objFoto = img;
                    imgProduto.Image = objFoto;
                    objImagem = _objAdministradora.ImgAdministradora;

                }

            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.Administradora objAdministradora = new Comum.Clases.Administradora();

            objAdministradora.Descricao = txtNome.Text.Trim();
            objAdministradora.Identificador = _IdentificadorAdministradora;
            objAdministradora.DescricaoTela = txtDescricaoTela.Text.Trim();
            objAdministradora.Observacao = txtObservacao.Text;

            if (!string.IsNullOrEmpty(txtPercentualDesconto.Text.Trim()))
            {
                objAdministradora.PercentualDesconto = Convert.ToDecimal(txtPercentualDesconto.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtPercentualTarifa.Text.Trim()))
            {
                objAdministradora.PercentualTarifa = Convert.ToDecimal(txtPercentualTarifa.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtPercentualTarifaAnt.Text.Trim()))
            {
                objAdministradora.PercentualTarifaAntecipada = Convert.ToDecimal(txtPercentualTarifaAnt.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtValorDesconto.Text.Trim()))
            {
                objAdministradora.ValorDesconto = Convert.ToDecimal(txtValorDesconto.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtValorTarifa.Text.Trim()))
            {
                objAdministradora.ValorTarifa = Convert.ToDecimal(txtValorTarifa.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtValorTarifaAnt.Text.Trim()))
            {
                objAdministradora.ValorTarifaAntecipada = Convert.ToDecimal(txtValorTarifaAnt.Text.Trim());
            }

            if (objImagem != null)
            {
                objAdministradora.ImgAdministradora = objImagem;
            }


            if (string.IsNullOrEmpty(_IdentificadorAdministradora))
            {

                ContratoServico.Administradora.InserirAdministradora.PeticaoInserirAdministradora Peticao = new ContratoServico.Administradora.InserirAdministradora.PeticaoInserirAdministradora();
                ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora Resposta;

                Peticao.Administradora = objAdministradora;
                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora, ContratoServico.Administradora.InserirAdministradora.PeticaoInserirAdministradora>(Peticao,
                SDK.Operacoes.operacao.RecuperarAdministradora, new Comum.ParametrosTela.Generica()
                {
                    PreencherObjeto = true,
                    ExibirMensagemNenhumRegistro = false
                },null, true);


            }
            else
            {

                ContratoServico.Administradora.AtualizarAdministradora.PeticaoAtualizarAdministradora Peticao = new ContratoServico.Administradora.AtualizarAdministradora.PeticaoAtualizarAdministradora();
                ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora Resposta;

                Peticao.Administradora = objAdministradora;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


                Agente.Agente.InvocarServico<ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora, ContratoServico.Administradora.AtualizarAdministradora.PeticaoAtualizarAdministradora>(Peticao,
               SDK.Operacoes.operacao.RecuperarAdministradora, new Comum.ParametrosTela.Generica()
               {
                   PreencherObjeto = true,
                   ExibirMensagemNenhumRegistro = false
               }, null, true);

            }

        }

        #endregion

        #region "Eventos"
        private void lnkAlterarFoto_Click(object sender, EventArgs e)
        {
            try
            {

                if (fdgImgImagemAdministradora.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Cursor = Cursors.WaitCursor;

                    CaminhoImagem = fdgImgImagemAdministradora.FileName;
                    imgProduto.Load(fdgImgImagemAdministradora.FileName);


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

                        objImagem = picture;

                    }

                    Cursor = Cursors.Default;

                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                Cursor = Cursors.Default;
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

        private void txtPercentualTarifa_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualTarifa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void txtValorTarifa_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorTarifa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPercentualTarifaAnt_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualTarifaAnt);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorTarifaAnt_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorTarifaAnt);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPercentualDesconto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualDesconto);

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

        #endregion
    }
}
