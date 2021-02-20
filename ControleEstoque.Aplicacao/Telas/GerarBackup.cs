using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GerarBackup : Telas.TelaBase.BaseCE
    {
        private Boolean _restaurar = false;
        private System.ComponentModel.BackgroundWorker bgwInstalacao;

        public GerarBackup(Boolean Restaurar)
        {
            InitializeComponent();

            _restaurar = Restaurar;
            bgwInstalacao = new System.ComponentModel.BackgroundWorker();

            bgwInstalacao.DoWork += bgwInstalacao_DoWork;
            bgwInstalacao.RunWorkerCompleted += bgwInstalacao_RunWorkerCompleted;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnLogar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {

            MontarMenu(false);
            
            base.Inicializar();
        }
        private void bgwInstalacao_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                ExecutarBackup();
            }
            catch (Exception ex)
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, false);
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void bgwInstalacao_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar,false);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, false);
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void ExecutarBackup()
        {

            if (!string.IsNullOrEmpty(txtDiretorio.Text))
            {

                if (!_restaurar)
                {
                    Comum.Clases.TabelaColecao Tabelas = null;//Classes.Tabelas.GerarTabelas(Parametros.Parametros.InformacaoUsuario.Login);

                    if (Tabelas != null && Tabelas.Count > 0)
                    {

                        Tabelas = LogicaNegocio.Backup.GerarBackup(Tabelas, Parametros.Parametros.InformacaoUsuario.Login);

                        if (Tabelas != null && Tabelas.Count > 0)
                        {

                            StreamWriter w = null;
                            XmlSerializer s = null;

                            w = new StreamWriter(txtDiretorio.Text);
                            s = new XmlSerializer(typeof(Comum.Clases.TabelaColecao));
                            s.Serialize(w, Tabelas);

                            w.Close();
                            w.Dispose();
                            Aplicacao.Classes.Util.ExibirMensagemSucesso("Backup Gerado com Sucesso.");
                            this.Close();
                        }
                    }
                }
                else
                {
                    StreamReader w = null;
                    Comum.Clases.TabelaColecao Tabelas = null;
                    XmlSerializer s = new XmlSerializer(typeof(Comum.Clases.TabelaColecao));
                    w = new StreamReader(txtDiretorio.Text);
                    Tabelas = (Comum.Clases.TabelaColecao)(s.Deserialize(w));

                    w.Close();
                    w.Dispose();

                    if (Tabelas != null && Tabelas.Count > 0)
                    {

                        LogicaNegocio.Backup.RestaurarBackup(Tabelas, Parametros.Parametros.InformacaoUsuario.Login);

                        Aplicacao.Classes.Util.ExibirMensagemSucesso("Restauração Executada com Sucesso.");
                        this.Close();
                    }
                }
            }
            else
            {
                Aplicacao.Classes.Util.ExibirMensagemInformacao("Favor Selecionar o diretorio");
            }

        }

        private void btnDiretorio_Click(object sender, EventArgs e)
        {
            try
            {

                if (!_restaurar)
                {

                    sfdBackup.FileName = "Backup_" + DateTime.Now.ToShortDateString().Replace("/", "_");
                    sfdBackup.DefaultExt = "xml";
                    sfdBackup.InitialDirectory = Environment.CurrentDirectory;
                    sfdBackup.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                    if (sfdBackup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        txtDiretorio.Text = sfdBackup.FileName;
                    }
                }
                else
                {
                    //ofdRestaurar.FileName = "Backup_" + DateTime.Now.ToShortDateString().Replace("/", "_");
                    ofdRestaurar.DefaultExt = "xml";
                    ofdRestaurar.InitialDirectory = Environment.CurrentDirectory;
                    ofdRestaurar.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                    if (ofdRestaurar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        txtDiretorio.Text = ofdRestaurar.FileName;
                    }
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {

                Form.CheckForIllegalCrossThreadCalls = false;

                bgwInstalacao.RunWorkerAsync();
                             
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
