using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using Ionic.Zip;
using System.IO;

namespace Informatiz.ControleEstoque.Atualizador
{
    public partial class Atualizador : Form
    {

        private System.ComponentModel.BackgroundWorker bgwAtualizador = null;

        public Atualizador()
        {
            InitializeComponent();

            bgwAtualizador = new System.ComponentModel.BackgroundWorker();

            bgwAtualizador.DoWork += new System.ComponentModel.DoWorkEventHandler(bgwImagemCentro_DoWork);
            bgwAtualizador.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgwImagemCentro_RunWorkerCompleted);


        }

        private void Atualizador_Load(object sender, EventArgs e)
        {
            //' obtém a versão do sistema

            string Versao = Application.ProductVersion.Replace("1.0.", string.Empty);

            lblVersao.Text = "Versão: 1.0 Build(" + Versao + ")";

            foreach (System.Diagnostics.Process objProcesso in System.Diagnostics.Process.GetProcesses())
            {

                if (objProcesso != null && objProcesso.ProcessName.Contains("Informatiz.ControleEstoque.Aplicacao"))
                {
                    objProcesso.Kill();
                }

            } 

            

            System.Threading.Thread.Sleep(5000);

            bgwAtualizador.RunWorkerAsync();


        }

        private void bgwImagemCentro_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                AtualizarVersao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "I - GERENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwImagemCentro_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {

                MessageBox.Show("Atualização Completa", "I - GERENCE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "I - GERENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarVersao()
        {

            pgbProgresso.Value += 1;

            string Diretorio = frmUtil.Util.RetonarLocalRaiz();

            pgbProgresso.Value += 1;

            Diretorio += "\\CE";
            string DiretorioDestino = Diretorio + "\\ATUALIZACAO";

            pgbProgresso.Value += 1;

            if (!Directory.Exists(Diretorio))
            {
                Directory.CreateDirectory(Diretorio);
            }

            pgbProgresso.Value += 1;

            if (Directory.Exists(DiretorioDestino))
            {
                Directory.Delete(DiretorioDestino, true);
                Directory.CreateDirectory(DiretorioDestino);
            }

            pgbProgresso.Value += 1;

            string Arquivos = Diretorio + "\\Arquivos.zip";

            if (System.IO.File.Exists(Arquivos))
            {
                using (ZipFile zip = ZipFile.Read(Arquivos))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(DiretorioDestino, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }

            pgbProgresso.Value += 1;

            string DiretorioAplicacao = Environment.CurrentDirectory;
            string DiretorioPai = DiretorioAplicacao.Replace("\\ATUALIZADOR", string.Empty);

            pgbProgresso.Value += 1;

            string[] ListaArquivos = Directory.GetFiles(DiretorioDestino);
            string[] ListaDiretorios = Directory.GetDirectories(DiretorioDestino);

            pgbProgresso.Value += 1;

            if (ListaArquivos != null)
            {
                foreach (string item in ListaArquivos)
                {

                    string NomeArquivo = item.Split(new char[] { Convert.ToChar("\\") }).LastOrDefault();
                    string Arquivo = DiretorioPai + "\\" + NomeArquivo;

                    File.Copy(item, Arquivo,true);

                }
            }
            pgbProgresso.Value += 1;
            
            if (ListaDiretorios != null )
            {
                foreach (string item in ListaDiretorios)
                {

                    string[] ListaArquivosSubPasta = Directory.GetFiles(item);

                    if (ListaArquivosSubPasta != null)
                    {
                        foreach (string itemArquivo in ListaArquivosSubPasta)
                        {

                            string[] Parametros = itemArquivo.Split(new char[] { Convert.ToChar("\\") });

                            string NomeArquivo = Parametros.LastOrDefault();
                            string NomePastaArquivo = Parametros[(Parametros.Count() - 2)];
                            string Arquivo = DiretorioPai + "\\" + NomePastaArquivo + "\\" + NomeArquivo;

                            File.Copy(item, Arquivo,true);

                        }
                    }

                }
            }

            pgbProgresso.Value += 1;
            
            System.Diagnostics.Process.Start(DiretorioPai + "\\Informatiz.ControleEstoque.Aplicacao.exe");

        }
    }
}
