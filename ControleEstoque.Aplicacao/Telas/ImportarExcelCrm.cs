using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.IO;
using System.Diagnostics;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class ImportarExcelCrm : TelaBase.BaseCE
    {
        public ImportarExcelCrm()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion
        #region "Variaveis"
        private List<Comum.Clases.TipoCrm> _tiposCrm = null;
        private Boolean _planilhaImportada = false;

        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);
            RecuperarTipoCrm();
            base.Inicializar();
        }

        private void RecuperarTipoCrm()
        {


            ContratoServico.TipoCrm.PesquisarTipoCrm.PeticaoPesquisarTipoCrm Peticao = new ContratoServico.TipoCrm.PesquisarTipoCrm.PeticaoPesquisarTipoCrm()
            {
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Usuario = Parametros.Parametros.InformacaoUsuario.Login
            };

            Agente.Agente.InvocarServico<ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm, ContratoServico.TipoCrm.PesquisarTipoCrm.PeticaoPesquisarTipoCrm>(Peticao,
                     SDK.Operacoes.operacao.PesquisarTipoCrm, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = true }, null, true);

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
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.PesquisarTipoCrm)
            {
                _tiposCrm = ((ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm)objSaida).TiposCrm;
                PreencherTiposCrm();
            }
            else if (operacao == SDK.Operacoes.operacao.GerarAgendamentoAutomatico)
            {
                base.objNotificacao.ExibirMensagem("CRM cadastrado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                _planilhaImportada = true;
            }

        }

        private void PreencherTiposCrm()
        {

            if (_tiposCrm != null && _tiposCrm.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_tiposCrm, "Identificador", "Descricao");

                cmbTipoCrm = frmWindows.Util.PreencherCombobox(cmbTipoCrm, Items);

            }
        }

        #endregion

        #region "Eventos"
        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbTipoCrm.SelectedItem == null)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O tipo do crm é obrigatório");
                }

                if (string.IsNullOrEmpty(txtArquivo.Text))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório selecionar o arquivo");
                }

                var extension = Path.GetExtension(txtArquivo.Text).ToLower();
                System.Data.DataSet ds;

                using (var stream = new FileStream(txtArquivo.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    IExcelDataReader reader = null;
                    if (extension == ".xls")
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (extension == ".xlsx")
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else if (extension == ".csv")
                    {
                        reader = ExcelReaderFactory.CreateCsvReader(stream);
                    }

                    if (reader == null)
                        return;

                    var openTiming = sw.ElapsedMilliseconds;
                    // reader.IsFirstRowAsColumnNames = firstRowNamesCheckBox.Checked;
                    using (reader)
                    {
                        ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            UseColumnDataType = false,
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                    }

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        Comum.Clases.CRM objCrm = null;
                        List<Comum.Clases.CRM> objListaCrm = new List<Comum.Clases.CRM>();
                        string DesNomeCliente = string.Empty;
                        string Numero = string.Empty;
                        List<Comum.Clases.Cidade> objColCidades = null;
                        List<Comum.Clases.Bairro> objColBairros = null;
                        List<Comum.Clases.Endereco> objColEnderecoos = null;
                        List<Comum.Clases.Agendamento> objColAgendamento = null;
                        string Cidade = string.Empty;
                        string Bairro = string.Empty;
                        string Endereco = string.Empty;
                        string Cep = string.Empty;
                        string DescricaoProximoContato = string.Empty;
                        string DataProximoContato = string.Empty;
                        string HoraProximoContato = string.Empty;
                        string Data = string.Empty;
                        string Hora = string.Empty;
                        string DataHora = string.Empty;
                        string TelefoneCelular = string.Empty;
                        string TelefoneFixo = string.Empty;
                        string Responsavel = string.Empty;
                        string PrimeiroContatoCliente = string.Empty;
                        StringBuilder strObservacao = null;

                        foreach (DataRow dr in dt.Rows)
                        {
                            strObservacao = new StringBuilder();
                            Numero = frmUtil.Util.AtribuirValorObj(dr["NUMERO"], typeof(string)) as string;
                            Cidade = frmUtil.Util.AtribuirValorObj(dr["CIDADE"], typeof(string)) as string;
                            Bairro = frmUtil.Util.AtribuirValorObj(dr["BAIRRO"], typeof(string)) as string;
                            Endereco = frmUtil.Util.AtribuirValorObj(dr["ENDERECO"], typeof(string)) as string;
                            Cep = frmUtil.Util.AtribuirValorObj(dr["CEP"], typeof(string)) as string;
                            DataProximoContato = frmUtil.Util.AtribuirValorObj(dr["DAT_PROX_CONTATO"], typeof(string)) as string;
                            HoraProximoContato = frmUtil.Util.AtribuirValorObj(dr["HOR_PROX_CONTATO"], typeof(string)) as string;
                            Data = frmUtil.Util.AtribuirValorObj(dr["DATA"], typeof(string)) as string;
                            Hora = frmUtil.Util.AtribuirValorObj(dr["HORA"], typeof(string)) as string;

                            TelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["CELULAR"], typeof(string)) as string;
                            TelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["TELEFONE_FIXO"], typeof(string)) as string;
                            Responsavel = frmUtil.Util.AtribuirValorObj(dr["RESPONSAVEL"], typeof(string)) as string;
                            PrimeiroContatoCliente = frmUtil.Util.AtribuirValorObj(dr["PRIMEIRO_CONTATO_CLIENTE"], typeof(string)) as string;

                            if (!string.IsNullOrEmpty(TelefoneCelular))
                            {
                                strObservacao.AppendLine(string.Format("Telefone Celular: {0}", TelefoneCelular));
                            }

                            if (!string.IsNullOrEmpty(TelefoneFixo))
                            {
                                strObservacao.AppendLine(string.Format("Telefone Fixo: {0}", TelefoneFixo));
                            }

                            if (!string.IsNullOrEmpty(Responsavel))
                            {
                                strObservacao.AppendLine(string.Format("Responsável: {0}", Responsavel));
                            }

                            if (!string.IsNullOrEmpty(PrimeiroContatoCliente))
                            {
                                strObservacao.AppendLine(string.Format("Primeiro Contato Cliente: {0}", PrimeiroContatoCliente));
                            }

                            if (!string.IsNullOrEmpty(DataProximoContato))
                            {
                                DataProximoContato = DataProximoContato.Split(Convert.ToChar(" ")).FirstOrDefault();
                            }

                            if (!string.IsNullOrEmpty(HoraProximoContato))
                            {
                                HoraProximoContato = HoraProximoContato.Split(Convert.ToChar(" ")).LastOrDefault();
                            }

                            if (!string.IsNullOrEmpty(Data))
                            {
                                Data = Data.Split(Convert.ToChar(" ")).FirstOrDefault();
                            }

                            if (!string.IsNullOrEmpty(Hora))
                            {
                                Hora = Hora.Split(Convert.ToChar(" ")).LastOrDefault();
                            }

                            DescricaoProximoContato = frmUtil.Util.AtribuirValorObj(dr["DESCRIC_PROX_CONTATO"], typeof(string)) as string;

                            objColAgendamento = new List<Comum.Clases.Agendamento>();

                            if (!string.IsNullOrEmpty(DescricaoProximoContato) || !string.IsNullOrEmpty(DataProximoContato) || !string.IsNullOrEmpty(HoraProximoContato))
                            {

                                objColAgendamento.Add(new Comum.Clases.Agendamento()
                                {
                                    Descricao = DescricaoProximoContato,
                                    DataAtendimento = (!string.IsNullOrEmpty(DataProximoContato) && !string.IsNullOrEmpty(HoraProximoContato) ? Convert.ToDateTime(string.Format("{0} {1}", DataProximoContato, HoraProximoContato)) :
                                                       (!string.IsNullOrEmpty(DataProximoContato) ? Convert.ToDateTime(string.Format("{0} {1}", DataProximoContato, "00:00")) : DateTime.MinValue))
                                });
                            }

                            DataHora = (!string.IsNullOrEmpty(DataProximoContato) && !string.IsNullOrEmpty(HoraProximoContato) ? string.Format("{0} {1}", DataProximoContato, HoraProximoContato) :
                                       !string.IsNullOrEmpty(DataProximoContato) ? string.Format("{0} {1}", DataProximoContato, string.Empty) : string.Empty);

                            if (!string.IsNullOrEmpty(Endereco) || !string.IsNullOrEmpty(Cep))
                            {
                                objColEnderecoos = new List<Comum.Clases.Endereco>();
                                objColEnderecoos.Add(new Comum.Clases.Endereco()
                                {
                                    DescricaoRua = Endereco,
                                    Numero = (!string.IsNullOrEmpty(Numero) ? Convert.ToInt32(Numero) : 0),
                                    DescricaoCep = Cep,
                                    Complemento = frmUtil.Util.AtribuirValorObj(dr["COMPLEMENTO"], typeof(string)) as string,
                                    DesReferencia = frmUtil.Util.AtribuirValorObj(dr["PONTO_REFERENCIA"], typeof(string)) as string
                                });
                            }

                            if (!string.IsNullOrEmpty(Bairro))
                            {
                                objColBairros = new List<Comum.Clases.Bairro>();
                                objColBairros.Add(new Comum.Clases.Bairro()
                                {
                                    Nome = Bairro,
                                    Enderecos = objColEnderecoos
                                });
                            }

                            if (!string.IsNullOrEmpty(Cidade))
                            {
                                objColCidades = new List<Comum.Clases.Cidade>();
                                objColCidades.Add(new Comum.Clases.Cidade()
                                {
                                    Nome = Cidade,
                                    Bairros = objColBairros
                                });
                            }

                            objCrm = new Comum.Clases.CRM()
                            {

                                Ativo = true,
                                Consultor = frmUtil.Util.AtribuirValorObj(dr["CONSULTOR"], typeof(string)) as string,
                                Descricao = string.Format("{0} | {1} | {2} | {3}", frmUtil.Util.AtribuirValorObj(dr["MIDIA_INDICACAO"], typeof(string)) as string,
                                                                             frmUtil.Util.AtribuirValorObj(dr["CELULAR"], typeof(string)) as string,
                                                                             frmUtil.Util.AtribuirValorObj(dr["RESPOSTA_CLIENTE"], typeof(string)) as string,
                                                                             DataHora),
                                FuncionarioCadastro = new Comum.Clases.Pessoa() { Identificador = Parametros.Parametros.InformacaoUsuario.Identificador },
                                Observacao = strObservacao.ToString(),
                                Atendimentos = objColAgendamento,
                                TipoCrm = new Comum.Clases.TipoCrm(),
                                StatusCrm = new Comum.Clases.StatusCrm() { Identificador = "ID", Codigo = "CODIGO", CorRGB = "COR", Descricao = "DESCRICAO" }
                            };

                            DesNomeCliente = frmUtil.Util.AtribuirValorObj(dr["CLIENTE"], typeof(string)) as string;

                            if (!string.IsNullOrEmpty(DesNomeCliente))
                            {
                                objCrm.Cliente = new Comum.Clases.Pessoa()
                                {
                                    cnpj = frmUtil.Util.AtribuirValorObj(dr["CNPJ"], typeof(string)) as string,
                                    cpf = frmUtil.Util.AtribuirValorObj(dr["CPF"], typeof(string)) as string,
                                    RG = frmUtil.Util.AtribuirValorObj(dr["RG"], typeof(string)) as string,
                                    InscricaoEstadual = frmUtil.Util.AtribuirValorObj(dr["INSC_ESTAD"], typeof(string)) as string,
                                    DesNome = DesNomeCliente,
                                    Empresa = new Comum.Clases.Empresa() { Identificador = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador },
                                    DesTelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["CELULAR"], typeof(string)) as string,
                                    DesTelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["TELEFONE_FIXO"], typeof(string)) as string,
                                    DesNomeFantasia = frmUtil.Util.AtribuirValorObj(dr["NOME_FANTASIA"], typeof(string)) as string,
                                    DesEmail = frmUtil.Util.AtribuirValorObj(dr["EMAIL"], typeof(string)) as string,
                                    EnderecoCompleto = new Comum.Clases.Estado()
                                    {
                                        Codigo = frmUtil.Util.AtribuirValorObj(dr["UNIF_ESTADO"], typeof(string)) as string,
                                        Cidades = objColCidades
                                    }
                                };

                            }
                            else
                            {
                                objCrm.Cliente = new Comum.Clases.Pessoa();
                            }

                            objListaCrm.Add(objCrm);
                        }

                        Comum.Clases.TipoCrm TipoCrmDefault = null;

                        if (cmbTipoCrm.SelectedItem != null)
                        {
                            TipoCrmDefault = (Comum.Clases.TipoCrm)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoCrm, _tiposCrm, "Identificador"));
                        }

                        ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico Peticao = new ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico()
                        {
                            CodigoTipoCrmPadrao = (TipoCrmDefault != null && !string.IsNullOrEmpty(TipoCrmDefault.Codigo) ? TipoCrmDefault.Codigo : Parametros.Parametros.ParametrosAplicacao.CodigoTipoCrmDefault),
                            DescricaoClientePadrao = Parametros.Parametros.ParametrosAplicacao.DescricaoClienteDefault,
                            CRMs = objListaCrm,
                            IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                            Usuario = Parametros.Parametros.InformacaoUsuario.Login
                        };

                        Agente.Agente.InvocarServico<ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico, ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico>(Peticao,
                                 SDK.Operacoes.operacao.GerarAgendamentoAutomatico, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = true }, null, true);

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
        #endregion

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {

                ofdExcel.Filter = "Excel Worksheets 2003(*.xls)|*.xls|Excel Worksheets 2007(*.xlsx)|*.xlsx";
                ofdExcel.Title = "Selecione o Arquivo";

                if (ofdExcel.ShowDialog() == DialogResult.OK)
                {
                    txtArquivo.Text = ofdExcel.FileName;
                }


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void ImportarExcelCrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_planilhaImportada)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
