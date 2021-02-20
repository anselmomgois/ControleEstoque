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
    public partial class ExibirFoto : Form
    {
        private Image _Foto;
       public ExibirFoto(Image Foto)
        {
            InitializeComponent();
            _Foto = Foto;
        }

        private void ExibirFoto_Load(object sender, EventArgs e)
        {
            try
            {

                imgProduto.Image = _Foto;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

  
        private void imgProduto_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //Define o cursor para Hand
                Cursor.Current = Cursors.Hand;
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

                this.Close();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

    }
}
