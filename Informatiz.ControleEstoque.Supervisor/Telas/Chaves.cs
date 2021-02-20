using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Supervisor
{
    public partial class Chaves : Telas.TelaBase.BaseCE
    {
        public Chaves()
        {
            InitializeComponent();

            this.Inicializar();

            ContratoServico.RecuperarChaves.Peticao objPeticao = new ContratoServico.RecuperarChaves.Peticao();
            Comunicacao.Proxy objProxy = new Comunicacao.Proxy();

            
            objPeticao.Usuario = "Supervisor";

            ContratoServico.RecuperarChaves.Respuesta objRespuesta = objProxy.RecuperarChaves(objPeticao);

            objChaves = objRespuesta.Chaves;

            if (objRespuesta.Chaves != null)
            {

                foreach (Comum.Clases.Chave c in objRespuesta.Chaves)
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

        List<Comum.Clases.Chave> objChaves = null;

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
                //Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { DesErro = ex.Message, Usuario = objParametros.InformacaoUsuario.Login });
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
                //Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { DesErro = ex.Message, Usuario = objParametros.InformacaoUsuario.Login });
            }
        }
    }
}
