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
    public partial class Chaves :TelaBase.BaseCE
    {
        public Chaves()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            CarregarTela();
            base.Inicializar();
            this.pnlBase.Controls.Add(dgvChaves);
            dgvChaves.Dock = DockStyle.Fill;
        }
               
        List<Comum.Clases.Chave> objChaves = null;

        private void CarregarTela()
        {

            ContratoServico.ChaveAcesso.RecuperarChaves.PeticaoRecuperarChaves Peticao = new ContratoServico.ChaveAcesso.RecuperarChaves.PeticaoRecuperarChaves()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
            };

            Agente.Agente.InvocarServico<ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves, ContratoServico.ChaveAcesso.RecuperarChaves.PeticaoRecuperarChaves>(Peticao,
                  SDK.Operacoes.operacao.RecuperarChaves, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);          
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

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarChaves)
            {

                objChaves = ((ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves)objSaida).Chaves;

                if (objChaves != null)
                {

                    foreach (Comum.Clases.Chave c in objChaves)
                    {

                        dgvChaves.Rows.Add();
                        dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[colChave.Index].Value = c.ChaveAcesso;
                        dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[colSessoes.Index].Value = c.QuantidadeSessoes;
                        dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[Validade.Index].Value = c.Validade;
                        dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[colIdentificador.Index].Value = c.Identificador;

                        if (c.SessoesInfinitas)
                        {
                            dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[ColSessoesInfinitas.Index].Value = Properties.Resources.circle_green;
                        }
                        else
                        {
                            dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[ColSessoesInfinitas.Index].Value = Properties.Resources.circle_red;
                        }

                        if (c.ValidadeInfinita)
                        {
                            dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[colValidadeInfinita.Index].Value = Properties.Resources.circle_green;
                        }
                        else
                        {
                            dgvChaves.Rows[dgvChaves.Rows.Count - 1].Cells[colValidadeInfinita.Index].Value = Properties.Resources.circle_red;
                        }

                    }
                }

            }


        }

        private void dgvChaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChaves.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colImprimir.Index)
                        {

                            RelatorioVisualizar frmRelatorio = new RelatorioVisualizar();

                            Comum.Clases.Chave objChave = (from Comum.Clases.Chave c in objChaves
                                                           where c.Identificador == dgvChaves.Rows[e.RowIndex].Cells[colIdentificador.Index].Value
                                                           select c).FirstOrDefault();

                            if (objChave != null)
                            {
                                DataSet.dtChaves objDataSet = new DataSet.dtChaves();
                                objDataSet.PopularDataSet(objChave);

                                frmRelatorio.FonteDados = objDataSet;
                                frmRelatorio.Relatorio = "Chave.rpt";

                                frmRelatorio.ShowDialog();
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

        private void dgvChaves_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvChaves.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colImprimir.Index)
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
    }
}
