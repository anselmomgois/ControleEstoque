using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.VendaTouch
{
    public partial class ucProduto : UserControl
    {

        public delegate void dProdutoSelecionado(Comum.Clases.ProdutoDisponivelVenda produto);
        public event dProdutoSelecionado EventoProdutoSelecionado;
        public System.Windows.Forms.BorderStyle BorderStyleImagem
        {
            get
            {
                return imgProduto.BorderStyle;
            }
            set
            {
                imgProduto.BorderStyle = value;
            }
        }

        public Comum.Clases.ProdutoDisponivelVenda P;

        public ucProduto(Comum.Clases.ProdutoDisponivelVenda p)
        {
            InitializeComponent();

            this.Tag = p.Produto.Identificador;
            P = p;
            lblProduto.Text = p.Produto.Descricao;
            imgProduto.Image = Comum.Clases.Util.byteArrayToImage(p.Produto.ImgProduto);
            imgProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            imgProduto.BackColor = Color.Transparent;
            //imgProduto.BorderStyle = BorderStyle.None;
            //imgProduto.Region = Region.FromHrgn(CreateRoundRectRgn(20, 20, Width, Height, 20, 20));
        }

        // [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        // private static extern IntPtr CreateRoundRectRgn
        //(
        //    int nLeftRect,     // x-coordinate of upper-left corner
        //    int nTopRect,      // y-coordinate of upper-left corner
        //    int nRightRect,    // x-coordinate of lower-right corner
        //    int nBottomRect,   // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        //);

        private void imgProduto_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            //imgProduto.BorderStyle = BorderStyle.Fixed3D;
        }

        private void imgProduto_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
            //imgProduto.BorderStyle = BorderStyle.None;
        }

        private void imgProduto_Click(object sender, EventArgs e)
        {
            BorderStyleImagem = BorderStyle.Fixed3D;
            EventoProdutoSelecionado(P);
        }

    }
}
